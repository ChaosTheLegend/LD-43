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

    public GameObject exit;
    public GameObject StartRoom;
    public List<GameObject> Rooms;
    public float LoadTime;
    public int MinSize;
    float tm;

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
                Instantiate(exit, Rooms[Rooms.Count - 1].transform.position, transform.rotation);
            }
            tm = -1000f;
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
