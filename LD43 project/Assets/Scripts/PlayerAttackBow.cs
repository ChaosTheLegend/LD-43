﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBow : MonoBehaviour {
    public Rigidbody2D arrow;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(arrow, GameObject.Find("Character").transform.position, Quaternion.identity);
        }

    }
}