using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 target;
	// Use this for initialization
	void Start () {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyObject", 10);
    }

    // Update is called once per frame
    void Update () {
        rb.velocity = Vector2.MoveTowards(transform.position, target, 40);
    }
    void DestroyObject()
    {
        Destroy(GameObject.Find("Arrow(Clone)"));
    }
}
