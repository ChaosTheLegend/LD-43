using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float health;

    public float force;
    public enum elements { fire, water, earth }
    public elements Element;
    public float ColldownTime;
    float timer;
    // Use this for initialization
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HitBox") && timer <= 0)
        {
            timer = ColldownTime;
            float multiplier = 1f;
            int Helement = other.GetComponent<HitboxControll>().Element;
            switch ((int)Element)
            {
                case (0):
                    switch (Helement)
                    {
                        case (0):
                            multiplier = 1f;
                            break;
                        case (1):
                            multiplier = 1.4f;
                            break;
                        case (2):
                            multiplier = 0.7f;
                            break;
                    }
                    break;
                case (1):
                    switch (Helement)
                    {
                        case (0):
                            multiplier = 1.4f;
                            break;
                        case (1):
                            multiplier = 1f;
                            break;
                        case (2):
                            multiplier = 0.7f;
                            break;
                    }
                    break;
                case (2):
                    switch (Helement)
                    {
                        case (0):
                            multiplier = 0.7f;
                            break;
                        case (1):
                            multiplier = 1.4f;
                            break;
                        case (2):
                            multiplier = 1f;
                            break;
                    }
                    break;
            }

            health -= other.GetComponent<HitboxControll>().Damage * multiplier;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 knockback = transform.position - player.transform.position;
            GetComponent<Rigidbody2D>().AddForce(knockback.normalized * force * other.GetComponent<HitboxControll>().Knockback);
        }
    }
}
