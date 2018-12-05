using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templates : MonoBehaviour {
    [Header("Corridors")]
    public GameObject[] LeftCorridors;
    public GameObject[] RightCorridors;
    public GameObject[] UpCorridors;
    public GameObject[] DownCorridors;
    [Header("3 ways")]
    public GameObject[] LeftWay;
    public GameObject[] RightWay;
    public GameObject[] UpWay;
    public GameObject[] DownWay;
    [Header("deadends")]
    public GameObject[] LeftEnd;
    public GameObject[] RightEnd;
    public GameObject[] UpEnd;
    public GameObject[] DownEnd;

    public GameObject Wall;
    public GameObject GenPanel;

    public GameObject exit;
    public GameObject chest;

    public GameObject StartRoom;
    public List<GameObject> Rooms;

    public List<GameObject> DeadEnds;
    public float LoadTime;
    public int MinSize;

    public enum Element {Ruby,Sapphire,Emerald};
    public Element element;
    float tm;
    public int level = 1;
    public bool generated = false;
    public bool cleared = false;
    public Weapons[] WeaponPool;


    private void Awake()
    {
        int RNG = (int)Random.Range(0, 3);
        element = (Element)RNG;
        tm = LoadTime;
    }
    private void Start()
    {
        Instantiate(StartRoom, Vector3.zero, transform.rotation);
    }

    private void Update()
    {
        
        if (cleared && generated)
        {
            GameObject Altar = GameObject.FindGameObjectWithTag("Altar");
            RegenerateEverything((int)Altar.GetComponent<AltarControll>().item.element);
            cleared = false;
            generated = false;
            return;
        }

        if (tm > 0)
        {
            tm -= Time.deltaTime;
        }
        else if(tm > -200f)
        {
            if (GameObject.FindGameObjectsWithTag("Room").Length <= MinSize)
            {
                Regenerate();
                return;
            }
            else
            {

                RemoveMissing();
                foreach (GameObject room in Rooms)
                {
                    try
                    {
                        if (room.CompareTag("Room"))
                        {
                            if (room.GetComponent<RoomControll>().Doors.transform.childCount == 1)
                            {
                                DeadEnds.Add(room);
                            }
                        }
                    }
                    catch { }
                }
                
                if (DeadEnds.Count < 3)
                {
                    Regenerate();
                    return;
                }



                Instantiate(exit, DeadEnds[DeadEnds.Count - 1].transform.position, transform.rotation, DeadEnds[DeadEnds.Count - 1].transform);
                DeadEnds.RemoveAt(DeadEnds.Count - 1);

                for (int i = 0; i < 2; i++)
                {
                    int RNG = Random.Range(0, DeadEnds.Count);
                    try
                    {
                        Instantiate(chest, DeadEnds[RNG].transform.position, transform.rotation);
                    }
                    catch { }
                    DeadEnds.RemoveAt(RNG);
                }
                GameObject[] Chests = GameObject.FindGameObjectsWithTag("Chest");
                foreach (GameObject Chest in Chests)
                {
                    Chest.GetComponent<ChestActivation>().Contance = WeaponPool[Random.Range(0, WeaponPool.Length)];
                }

                foreach (GameObject room in Rooms)
                {
                    try
                    {
                        if (room.CompareTag("Room"))
                        {
                            room.GetComponent<RoomUnloader>().generated = true;
                        }
                    }
                    catch { }
                }
                //Rooms = new List<GameObject>();
                generated = true;
                GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().active = true;
                GenPanel.SetActive(false);
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                
                foreach (GameObject enemy in enemies)
                {
                    try
                    {
                        enemy.GetComponent<EnemyHealth>().Element = (EnemyHealth.elements)element;
                    }
                    catch { }
                }
                
            }
            tm = -1000f;
        }
    }
    void RemoveMissing()
    {
        for (int i =0;i<Rooms.Count; i++)
        {
            if (Rooms[i] == null)
            {
                Rooms.RemoveAt(i);
            }
        }
    }

    void RegenerateEverything(int Elem)
    {
        level++;
        GenPanel.SetActive(true);
        foreach (GameObject room in Rooms)
        {
            Destroy(room.gameObject);
        }
        Rooms = new List<GameObject>();
        GameObject[] presets = GameObject.FindGameObjectsWithTag("Preset");
        GameObject Boss = GameObject.FindGameObjectWithTag("Boss");
        GameObject[] Pickups = GameObject.FindGameObjectsWithTag("PickUp");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject pres in presets)
        {
            Destroy(pres);
        }
        foreach (GameObject pick in Pickups)
        {
            Destroy(pick);
        }
        Destroy(Boss);
        player.transform.position = Vector3.zero;

        player.GetComponent<CharacterMovement>().active = false;
        element = (Element)Elem;
        DeadEnds = new List<GameObject>();
        Rooms = new List<GameObject>();
        Regenerate();
    }

    void Regenerate()
    {
        if (Rooms.Count > 0)
        {
            foreach (GameObject room in Rooms)
            {
                Destroy(room.gameObject);
            }
            Rooms = new List<GameObject>();
        } 
        Instantiate(StartRoom, Vector3.zero, transform.rotation);
        tm = LoadTime;
    }

}
