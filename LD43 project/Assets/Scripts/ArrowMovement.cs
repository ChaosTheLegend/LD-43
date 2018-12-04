using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {
    Rigidbody2D rb;
    //Vector2 target;
    Vector3 moveDirection;
    public float speed;
    // Use this for initialization
    void Start () {

        FindObjectOfType<AudioManager>().Play("BowFire");
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
        moveDirection.z = 0;
        moveDirection.Normalize();
        Invoke("DestroyObject", 3);
    }

    // Update is called once per frame
    void Update () {
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
        //rb.velocity = Vector2.MoveTowards(transform.position, target, 0);
    }
    void DestroyObject()
    {
        Destroy(gameObject);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //FindObjectOfType<AudioManager>().Play("ArrowHit");
        DestroyObject();
    }
}
