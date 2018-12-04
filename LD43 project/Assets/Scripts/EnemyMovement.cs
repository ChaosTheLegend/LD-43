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
        new WaitForSeconds(8);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.position.x > transform.position.x)
                x = 1;
            if (player.transform.position.x == transform.position.x)
                x = 0;
            if (player.transform.position.x < transform.position.x)
                x = -1;
            if (player.transform.position.y > transform.position.y)
                y = 1;
            if (player.transform.position.y == transform.position.y)
                y = 0;
            if (player.transform.position.y < transform.position.y)
                y = -1;
            rb.velocity = new Vector2(speed * x, speed * y);
    }
}
