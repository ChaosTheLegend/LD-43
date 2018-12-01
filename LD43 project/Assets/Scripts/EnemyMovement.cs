using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D rb;
    float x;
    float y;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Character").transform.position.x > transform.position.x)
            x = 1;
        if (GameObject.Find("Character").transform.position.x == transform.position.x)
            x = 0;
        if (GameObject.Find("Character").transform.position.x < transform.position.x)
            x = -1;
        if (GameObject.Find("Character").transform.position.y > transform.position.y)
            y = 1;
        if (GameObject.Find("Character").transform.position.y == transform.position.y)
            y = 0;
        if (GameObject.Find("Character").transform.position.y < transform.position.y)
            y = -1;
        rb.velocity = new Vector2(10 * x, 10 * y);
        //GameObject.Find("Character").transform.position;
    }
}
