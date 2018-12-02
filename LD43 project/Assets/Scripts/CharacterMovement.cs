﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float speed;
    int turn = 1;
    public SpriteRenderer rend;
    Rigidbody2D rb;

    float x;
    float y;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("d"))
        {
            turn = 1;
            //transform.localScale = new Vector2(-1, 1);
            //rend.flipX = false;
        }
        if (Input.GetKeyDown("a"))
        {
            turn = -1;
            //transform.localScale = new Vector2(1, -1);
            //rend.flipX = true;
        }
        transform.localScale = new Vector2(1*turn, 1);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x,y)*speed;
        
    }
}
