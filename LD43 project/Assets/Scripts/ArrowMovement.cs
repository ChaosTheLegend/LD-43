using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {
    Rigidbody2D rb;
    float x;
    float y;
	// Use this for initialization
	void Start () {
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyObject", 10);
    }

    // Update is called once per frame
    void Update () {
        rb.position = new Vector2(1 * x, 1 * y);
    }
    void DestroyObject()
    {
        Destroy(GameObject.Find("Arrow(Clone)"));
    }
}
