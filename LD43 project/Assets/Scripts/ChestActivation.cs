﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActivation : MonoBehaviour {
    public GameObject chestText;
    public GameObject weapon;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Instantiate(chestText, transform.position + new Vector3(0,0.9f,0), Quaternion.identity);
        }
    }
    void OnMouseDown()
    {
        Instantiate(weapon, transform.position + new Vector3(0, -0.9f, 0), Quaternion.identity);
    }
}
