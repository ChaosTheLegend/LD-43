using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D rb;
    public int speed;
    float x;
    float y;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
            x = 1;
        if (GameObject.Find("Player").transform.position.x == transform.position.x)
            x = 0;
        if (GameObject.Find("Player").transform.position.x < transform.position.x)
            x = -1;
        if (GameObject.Find("Player").transform.position.y > transform.position.y)
            y = 1;
        if (GameObject.Find("Player").transform.position.y == transform.position.y)
            y = 0;
        if (GameObject.Find("Player").transform.position.y < transform.position.y)
            y = -1;
        rb.velocity = new Vector2(speed * x, speed * y);
        //GameObject.Find("Character").transform.position;
    }
}
