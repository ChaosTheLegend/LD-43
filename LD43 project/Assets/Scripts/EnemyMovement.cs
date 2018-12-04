using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D rb;
    public int speed;
    public bool active = false;
    float x;
    float y;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
       
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = player.transform.position - transform.position;
        if (active)
        {
            rb.velocity = dir * speed * Time.deltaTime;
        }
    }
}
