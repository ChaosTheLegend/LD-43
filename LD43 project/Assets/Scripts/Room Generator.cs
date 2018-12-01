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
    public GameObject[] end;
    public GameObject start;

    [Header("Generation properties")]
    public int size;
	
    int _total;
    int _dir;

    List<GameObject> _rooms = new List<GameObject>();
    List<GameObject> _taboorooms = new List<GameObject>();
    List<Bounds> _roombounds = new List<Bounds>();
    GameObject _prev;

    void Regenerate()
    {
        foreach (GameObject rm in _rooms)
        {
            Destroy(rm);
        }
        _rooms = new List<GameObject>();
        _taboorooms = new List<GameObject>();
        _roombounds = new List<Bounds>();
        _prev = null;
        _total = 0;

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
        } while (_total != size);
        CollectCreationPoints();
    }

    void GenerateOneRoom()
    {
        if (_total == 0)
        {
            GenerateFirstRoom();
            return;
        }

        if (_total+1 == size)
        {
            GenerateLastRoom();
            return;
        }

        List<GameObject> prefabs = GetPrefabs(_dir);
        prefabs = RemoveTaboo(prefabs);

        if (prefabs.Count == 0)
        {
            print("Deadend Detected!");
            _total--;
            _roombounds.RemoveAt(_roombounds.Count - 1);
            _rooms.Remove(_prev);
            Destroy(_prev);
            _prev = _rooms[_rooms.Count - 1];
            _dir = _prev.GetComponent<room>().exitdir;
            _taboorooms = new List<GameObject>();
            return;
        }

        GameObject ChoseRoom = prefabs[Random.Range(0, prefabs.Count)];
        GameObject newroom = Instantiate(ChoseRoom, Vector3.zero, transform.rotation);
        Vector3 spawnpos = _prev.GetComponent<room>().end.position - newroom.GetComponent<room>().dis;
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
        _dir = newroom.GetComponent<room>().exitdir;
        _total++;
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
        _dir = room.GetComponent<room>().exitdir;
        _prev = room;
        _total++;
    }
    void GenerateLastRoom()
    {
        GameObject room = Instantiate(end[_dir], Vector3.zero, transform.rotation);
        Vector3 spawnpos = _prev.GetComponent<room>().end.position - room.GetComponent<room>().dis;
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
                print("Deadend Detected!");
                _total--;
                _roombounds.RemoveAt(_roombounds.Count - 1);
                _rooms.Remove(_prev);
                Destroy(_prev);
                _prev = _rooms[_rooms.Count - 1];
                _dir = _prev.GetComponent<room>().exitdir;
                _taboorooms = new List<GameObject>();
                return;
            }
        }
        _rooms.Add(room);
        _roombounds.Add(newbounds);
        _total++;
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
        if (_total != size)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Regenerate();
            }
        }
    }
}
