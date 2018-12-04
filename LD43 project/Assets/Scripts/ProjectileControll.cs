using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControll : MonoBehaviour {
    public float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.position = transform.position + transform.right * speed * Time.deltaTime;
        //rb.velocity = Vector2.MoveTowards(transform.position, target, 0);
    }
}
