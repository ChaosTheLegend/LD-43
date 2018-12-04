﻿using System.Collections;
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
        if (HUD.publicHealth > 0)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        ItemControll inv = RotatingThing.GetComponent<ItemControll>();
        int type;
        if (inv.weapon[slot] != null)
        {
            type = (int)inv.weapon[slot]._type;
        }
        else
        {
            type = -1;
        }


        switch(type)
        {
            case (-1):
                bow.SetActive(false);
                sword.SetActive(false);
                spear.SetActive(false);
                break;
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
            //Play 'EquipBow' sound
            // FindObjectOfType<AudioManager>().Play("EquipBow");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot = 1;
            //Play 'EquipSword' sound
            //FindObjectOfType<AudioManager>().Play("EquipSword");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slot = 2;
            //Play 'EquipSpear' sound
            //FindObjectOfType<AudioManager>().Play("EquipSpear");
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
        if (FindNearestObject("Altar") != null && FindNearestObject("Altar").GetComponent<AltarControll>().usable)
        {
            GameObject other = FindNearestObject("Altar");
            Vector3 dis = transform.position - other.transform.position;
            float len = dis.magnitude;
            if (Input.GetKeyDown(KeyCode.E) && len <= 1.6f && inv.weapon[slot] != null && !other.GetComponent<AltarControll>().sacrifice) 
            {
                other.GetComponent<AltarControll>().item = inv.weapon[slot];
                inv.weapon[slot] = null;
                other.GetComponent<AltarControll>().sacrifice = true;  
            }
        }


        if (FindNearestObject("PickUp") != null)
        {
            GameObject other = FindNearestObject("PickUp");
            Vector3 dis = transform.position - other.transform.position;
            float len = dis.magnitude;
            if (Input.GetKeyDown(KeyCode.E) && len <= 1.2f)
            {
                Weapons buffer = other.GetComponent<DropControll>().item;
                if (inv.weapon[slot] != null)
                {
                    other.GetComponent<DropControll>().item = inv.weapon[slot];
                }
                else
                {
                    Destroy(other.gameObject);
                }
                inv.weapon[slot] = buffer;
                
                //buffer = null;
            }
        }


    }


    GameObject FindNearestObject(string tag)
    {
        GameObject output = null;
        float mindis = 1000f;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
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
