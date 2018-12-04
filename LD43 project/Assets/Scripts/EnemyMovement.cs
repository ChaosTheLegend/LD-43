using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D rb;
    public int speed;
    bool move;
    public bool active = false;
    float x;
    float y;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        new WaitForSeconds(8);
        move = false;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player.transform.position.x > transform.position.x && move == true)
                x = 1;
            if (player.transform.position.x == transform.position.x && move == true)
                x = 0;
            if (player.transform.position.x < transform.position.x && move == true)
                x = -1;
            if (player.transform.position.y > transform.position.y && move == true)
                y = 1;
            if (player.transform.position.y == transform.position.y && move == true)
                y = 0;
            if (player.transform.position.y < transform.position.y && move == true)
                y = -1;
            rb.velocity = new Vector2(speed * x, speed * y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            move = true;
        }
            
    }
}
