using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour {

    [Header("Rooms")]
    public GameObject[] upenter;
    public GameObject[] downenter;
    public GameObject[] leftenter;
    public GameObject[] rightenter;
    [Header("SplitRooms")]
    public GameObject[] Supenter;
    public GameObject[] Sdownenter;
    public GameObject[] Sleftenter;
    public GameObject[] Srightenter;
    
    public GameObject[] end;
    public GameObject start;

    [Header("Generation properties")]
    public int TreeSize;
    public int TwigSize;
    public float splitchance;
    public List<GameObject> twigs;
    int _main = 0;
    public int _twig = 0;
    int _dir = 0;
    bool spitlock = false;
    List<GameObject> _rooms = new List<GameObject>();
    List<GameObject> _taboorooms = new List<GameObject>();
    List<Bounds> _roombounds = new List<Bounds>();
    GameObject _prev;

    private void Awake()
    {
        twigs = new List<GameObject>();
    }
    void Regenerate()
    {
        foreach (GameObject rm in _rooms)
        {
            Destroy(rm);
        }
        twigs = new List<GameObject>();
        _rooms = new List<GameObject>();
        _taboorooms = new List<GameObject>();
        _roombounds = new List<Bounds>();
        _prev = null;
        _main = 0;
        _twig = 0;

        StartCoroutine(Generate());
    }

    void Start()
    {
        _rooms = new List<GameObject>();
        _roombounds = new List<Bounds>();
        //InvokeRepeating( "Generate", 0.2f, 0.2f );
        StartCoroutine(Generate());
    }
    IEnumerator Generate()
    {
        do
        {
            yield return new WaitForSeconds(0.08f);
            GenerateOneRoom();
        } while (_main != TreeSize);
        twigs = RemoveMissing(twigs);
        if (twigs.Count > 0)
        {
            _twig = 0;
            _prev = twigs[0];
            _dir = twigs[0].GetComponent<Room2>().exitdir[1];
            twigs.RemoveAt(0);
            StartCoroutine(GenerateTwig());
        }
    }

    IEnumerator GenerateTwig()
    {
        do
        {
            yield return new WaitForSeconds(0.08f);
            GenerateOneTwigRoom();
        } while (_twig != TwigSize);
        if (twigs.Count > 0)
        {
            twigs = RemoveMissing(twigs);
            _twig = 0;
            _prev = twigs[0];
            _dir = _prev.GetComponent<Room2>().exitdir[1];
            twigs.RemoveAt(0);
            StartCoroutine(GenerateTwig());
        }
    }

    void GenerateOneTwigRoom()
    {
        if (_twig + 1 == TwigSize)
        {
            GenerateLastTwigRoom();
            return;
        }

        List<GameObject> prefabs = GetPrefabs(_dir);
        prefabs = RemoveTaboo(prefabs);

        if (prefabs.Count == 0 && _twig > 1)
        {
            _twig--;
            _roombounds.RemoveAt(_roombounds.Count - 1);
            _rooms.Remove(_prev);
            Destroy(_prev);
            _prev = _rooms[_rooms.Count - 1];
            if (_prev.GetComponent<Room>())
            {
                _dir = _prev.GetComponent<Room>().exitdir;
            }
            else if (_prev.GetComponent<Room2>())
            {
                _dir = _prev.GetComponent<Room2>().exitdir[1];
            }
            _taboorooms = new List<GameObject>();
            return;
        }

        GameObject ChoseRoom = prefabs[Random.Range(0, prefabs.Count)];
        GameObject newroom = Instantiate(ChoseRoom, Vector3.zero, transform.rotation);
        Vector3 spawnpos = Vector3.zero;
        if (_prev.GetComponent<Room2>())
        {
            spawnpos = _prev.GetComponent<Room2>().end[1].position - newroom.GetComponent<Room>().dis;
        }
        else if (_prev.GetComponent<Room>())
        {
            spawnpos = _prev.GetComponent<Room>().end.position - newroom.GetComponent<Room>().dis;
        }
        newroom.transform.position = spawnpos;
        var ccollider = newroom.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.size = newbounds.size * 0.9999f;
        newbounds.center = ccollider.bounds.center;

        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
            {
                print("Intersection detected!");
                _taboorooms.Add(ChoseRoom);
                Destroy(newroom);
                return;
            }
        }
        _rooms.Add(newroom);
        _roombounds.Add(newbounds);
        _prev = newroom;
        _dir = newroom.GetComponent<Room>().exitdir;
        _twig++;
        _taboorooms = new List<GameObject>();
    }

    List<GameObject> RemoveMissing(List<GameObject> toClear)
    {
        List<GameObject> output = toClear;
        for (int i =0;i<output.Count;i++)
        {
            if (!output[i])
            {
                output.RemoveAt(i);
            }
        }

        return output;
    }

    void GenerateOneRoom()
    {
        if (_main == 0)
        {
            GenerateFirstRoom();
            return;
        }

        if (_main + 1 == TreeSize)
        {
            GenerateLastRoom();
            return;
        }

        if (Random.Range(0, 100) <= splitchance)
        {
            GenerateSplitRoom();
            return;
        }


        List<GameObject> prefabs = GetPrefabs(_dir);
        prefabs = RemoveTaboo(prefabs);

        if (prefabs.Count == 0)
        {
            _main--;
            _roombounds.RemoveAt(_roombounds.Count - 1);
            _rooms.Remove(_prev);
            Destroy(_prev);
            _prev = _rooms[_rooms.Count - 1];
            if (_prev.GetComponent<Room>())
            {
                _dir = _prev.GetComponent<Room>().exitdir;
            }
            else if (_prev.GetComponent<Room2>())
            {
                _dir = _prev.GetComponent<Room2>().exitdir[0];
            }
            _taboorooms = new List<GameObject>();
            return;
        }

        GameObject ChoseRoom = prefabs[Random.Range(0, prefabs.Count)];
        GameObject newroom = Instantiate(ChoseRoom, Vector3.zero, transform.rotation);
        Vector3 spawnpos = Vector3.zero;
        if (_prev.GetComponent<Room>())
        {
            spawnpos = _prev.GetComponent<Room>().end.position - newroom.GetComponent<Room>().dis;
        }
        if (_prev.GetComponent<Room2>())
        {
            spawnpos = _prev.GetComponent<Room2>().end[0].position - newroom.GetComponent<Room>().dis;
        }
        newroom.transform.position = spawnpos;
        var ccollider = newroom.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.size = newbounds.size * 0.9999f;
        newbounds.center = ccollider.bounds.center;
        
        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
            {
                print("Intersection detected!");
                _taboorooms.Add(ChoseRoom);
                Destroy(newroom);
                return;
            }
        }
        _rooms.Add(newroom);
        _roombounds.Add(newbounds);
        _prev = newroom;
        _dir = newroom.GetComponent<Room>().exitdir;
        _main++;
        _taboorooms = new List<GameObject>();
    }
    void GenerateSplitRoom()
    {
        List<GameObject> prefabs = GetSplitPrefabs(_dir);
        prefabs = RemoveTaboo(prefabs);

        if (prefabs.Count == 0)
        {
            _main--;
            _roombounds.RemoveAt(_roombounds.Count - 1);
            _rooms.Remove(_prev);
            Destroy(_prev);
            _prev = _rooms[_rooms.Count - 1];
            if (_prev.GetComponent<Room>())
            {
                _dir = _prev.GetComponent<Room>().exitdir;
            }
            else if (_prev.GetComponent<Room2>())
            {
                _dir = _prev.GetComponent<Room2>().exitdir[0];
            }
            _taboorooms = new List<GameObject>();
            return;
        }

        GameObject ChoseRoom = prefabs[Random.Range(0, prefabs.Count)];
        GameObject newroom = Instantiate(ChoseRoom, Vector3.zero, transform.rotation);
        Vector3 spawnpos = Vector3.zero;
        if (_prev.GetComponent<Room>())
        {
            spawnpos = _prev.GetComponent<Room>().end.position - newroom.GetComponent<Room2>().dis;
        }
        if (_prev.GetComponent<Room2>())
        {
            spawnpos = _prev.GetComponent<Room2>().end[0].position - newroom.GetComponent<Room2>().dis;
        }
        newroom.transform.position = spawnpos;
        var ccollider = newroom.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.size = newbounds.size * 0.9999f;
        newbounds.center = ccollider.bounds.center;

        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
            {
                print("Intersection detected!");
                _taboorooms.Add(ChoseRoom);
                Destroy(newroom);
                return;
            }
        }

        twigs.Add(newroom);
        _rooms.Add(newroom);
        _roombounds.Add(newbounds);
        _prev = newroom;
        _dir = newroom.GetComponent<Room2>().exitdir[0];
        _main++;
        _taboorooms = new List<GameObject>();
    }



        void GenerateFirstRoom()
    {
        GameObject room = Instantiate(start, Vector3.zero, transform.rotation);
        _rooms.Add(room);
        var ccollider = room.GetComponent<CompositeCollider2D>();
        var bounds = ccollider.bounds;
        bounds.size = bounds.size * 0.9999f;
        bounds.center = ccollider.bounds.center;
        _roombounds.Add(bounds);
        _dir = room.GetComponent<Room>().exitdir;
        _prev = room;
        _main++;
    }
    void GenerateLastRoom()
    {
        GameObject room = Instantiate(end[_dir], Vector3.zero, transform.rotation);
        Vector3 spawnpos = Vector3.zero;
        if (_prev.GetComponent<Room>())
        {
            spawnpos = _prev.GetComponent<Room>().end.position - room.GetComponent<Room>().dis;
        }
        else if (_prev.GetComponent<Room2>())
        {
            spawnpos = _prev.GetComponent<Room2>().end[0].position - room.GetComponent<Room>().dis;
        }
        room.transform.position = spawnpos;
        var ccollider = room.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.size = newbounds.size * 0.9999f;
        newbounds.center = ccollider.bounds.center;
        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
            {               
                Destroy(room);
                _main--;
                _roombounds.RemoveAt(_roombounds.Count - 1);
                _rooms.Remove(_prev);
                Destroy(_prev);
                _prev = _rooms[_rooms.Count - 1];
                if (_prev.GetComponent<Room>())
                {
                    _dir = _prev.GetComponent<Room>().exitdir;
                }
                if (_prev.GetComponent<Room2>())
                {
                    _dir = _prev.GetComponent<Room2>().exitdir[0];
                }
                _taboorooms = new List<GameObject>();
                return;
            }
        }
        _rooms.Add(room);
        _roombounds.Add(newbounds);
        _main++;
    }

    void GenerateLastTwigRoom()
    {
        GameObject room = Instantiate(end[_dir], Vector3.zero, transform.rotation);
        Vector3 spawnpos = Vector3.zero;
        if (_prev.GetComponent<Room>())
        {
            spawnpos = _prev.GetComponent<Room>().end.position - room.GetComponent<Room>().dis;
        }
        else if (_prev.GetComponent<Room2>())
        {
            spawnpos = _prev.GetComponent<Room2>().end[1].position - room.GetComponent<Room>().dis;
        }
        room.transform.position = spawnpos;
        var ccollider = room.GetComponent<CompositeCollider2D>();
        var newbounds = ccollider.bounds;
        newbounds.size = newbounds.size * 0.9999f;
        newbounds.center = ccollider.bounds.center;
        foreach (var bounds in _roombounds)
        {
            if (bounds.Intersects(newbounds))
            {
                Destroy(room);
                _main--;
                _roombounds.RemoveAt(_roombounds.Count - 1);
                _rooms.Remove(_prev);
                Destroy(_prev);
                _prev = _rooms[_rooms.Count - 1];
                if (_prev.GetComponent<Room>())
                {
                    _dir = _prev.GetComponent<Room>().exitdir;
                }
                if (_prev.GetComponent<Room2>())
                {
                    _dir = _prev.GetComponent<Room2>().exitdir[0];
                }
                _taboorooms = new List<GameObject>();
                return;
            }
        }
        _rooms.Add(room);
        _roombounds.Add(newbounds);
        _twig++;
    }


    List<GameObject> RemoveTaboo(List<GameObject> toClear)
    {
        List<GameObject> output = new List<GameObject>();
        output = toClear;
        foreach (GameObject troom in _taboorooms)
        {
            output.Remove(troom);
        }

        return output;
    }
    List<GameObject> GetPrefabs(int dir)
    {
        switch (dir)
        {
            case 0:
                return downenter.ToList();

            case 1:
                return rightenter.ToList();

            case 2:
                return leftenter.ToList();

            case 3:
                return upenter.ToList();

            default:
                return new List<GameObject>();
        }
    }

    List<GameObject> GetSplitPrefabs(int dir)
    {
        switch (dir)
        {
            case 0:
                return Sdownenter.ToList();

            case 1:
                return Srightenter.ToList();

            case 2:
                return Sleftenter.ToList();

            case 3:
                return Supenter.ToList();

            default:
                return new List<GameObject>();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Bounds bound in _roombounds)
        {
            Gizmos.DrawWireCube(bound.center, bound.size);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Regenerate();
        }
    }
}
