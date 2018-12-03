using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryC : MonoBehaviour {
    public GameObject player;
    public GameObject bow;
    public GameObject sword;
    public GameObject spear;
    public GameObject RotatingThing;
    public int slot;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        ItemControll inv = RotatingThing.GetComponent<ItemControll>();
        int type = (int)inv.weapon[slot]._type;


        switch(type)
        {
            case (0):
            bow.SetActive(true);
            sword.SetActive(false);
            spear.SetActive(false);
                break;
            case (1):
                bow.SetActive(false);
                sword.SetActive(true);
                spear.SetActive(false);
                break;
            case (2):
                bow.SetActive(false);
                sword.SetActive(false);
                spear.SetActive(true);
                break;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slot = 2;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (slot < 2)
            {
                slot++;
            }
            else
            {
                slot = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (slot > 0)
            {
                slot--;
            }
            else
            {
                slot = 2;
            }
        }

        if (FindNearestPickUp() != null)
        {
            GameObject other = FindNearestPickUp();
            Vector3 dis = transform.position - other.transform.position;
            float len = dis.magnitude;
            if (Input.GetKeyDown(KeyCode.E) && len <= 1.2f)
            {
                Weapons buffer = other.GetComponent<DropControll>().item;
                other.GetComponent<DropControll>().item = inv.weapon[slot];
                inv.weapon[slot] = buffer;
                
                //buffer = null;
            }
        }


    }


    GameObject FindNearestPickUp()
    {
        GameObject output = null;
        float mindis = 1000f;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PickUp");
        if (objs.Length > 0)
        {
            foreach (GameObject obj in objs)
            {
                Vector3 dis = transform.position - obj.transform.position;
                float len = dis.magnitude;
                if (len < mindis)
                {
                    mindis = len;
                    output = obj;
                }
            }
        }
        return output;
    }
}
