﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControll : MonoBehaviour {

    int weapon;
    public GameObject rotatingthing;
    public Transform Player;
    public Vector3 mouse;
    public Vector3 dis;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = mouse - Player.localPosition;
        float angle = Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg;
        if (angle > 90 || angle < -90)
        {
            rotatingthing.transform.localScale = new Vector3(-1, 1, 1);
            angle = angle - 180;
        }
        else
        {
            rotatingthing.transform.localScale = new Vector3(1, 1, 1);
        }
        rotatingthing.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angle);

	}
}
