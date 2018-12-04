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
   

    public GameObject exit;
    public GameObject chest;

    public GameObject StartRoom;
    public List<GameObject> Rooms;

    public List<GameObject> DeadEnds;
    public float LoadTime;
    public int MinSize;
    float tm;

    public bool generated = false;

    public Weapons[] WeaponPool;


    private void Awake()
    {
        tm = LoadTime;
    }
    private void Start()
    {
        Instantiate(StartRoom, Vector3.zero, transform.rotation);
    }

    private void Update()
    {
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
                    if (room.CompareTag("Room"))
                    {
                        if (room.GetComponent<RoomControll>().Doors.transform.childCount == 1)
                        {
                            DeadEnds.Add(room);
                        }
                    }
                }
                
                if (DeadEnds.Count < 3)
                {
                    Regenerate();
                    return;
                }



                Instantiate(exit, DeadEnds[DeadEnds.Count - 1].transform.position, transform.rotation);
                DeadEnds.RemoveAt(DeadEnds.Count - 1);

                for (int i = 0; i < 2; i++)
                {
                    int RNG = Random.Range(0, DeadEnds.Count);
                    Instantiate(chest, DeadEnds[RNG].transform.position, transform.rotation);
                    DeadEnds.RemoveAt(RNG);
                }
                GameObject[] Chests = GameObject.FindGameObjectsWithTag("Chest");
                foreach (GameObject Chest in Chests)
                {
                    Chest.GetComponent<ChestActivation>().Contance = WeaponPool[Random.Range(0, WeaponPool.Length)];
                }

                foreach (GameObject room in Rooms)
                {
                    if (room.CompareTag("Room"))
                    {
                        room.GetComponent<RoomUnloader>().generated = true;
                    }
                }
                Rooms = new List<GameObject>();
                generated = true;
                
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


    void Regenerate()
    {
        
        foreach (GameObject room in Rooms)
        {
            Destroy(room.gameObject);
        }
        Rooms = new List<GameObject>();
        Instantiate(StartRoom, Vector3.zero, transform.rotation);
        tm = LoadTime;
        
    }

}
