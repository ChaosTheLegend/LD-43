using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControll : MonoBehaviour {
    public int Health;
    public float Cooldown;
    float tm;
    private void Update()
    {
        if (tm > 0)
        {
            tm -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            tm = Cooldown;
            Health--;
        }
    }


}
