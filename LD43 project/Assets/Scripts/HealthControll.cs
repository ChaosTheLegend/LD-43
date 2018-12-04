using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControll : MonoBehaviour {
    public int Health;
    public float Cooldown;
    public float tm;
    public Collider2D HitBox;
    private void Update()
    {
        if (tm > 0)
        {
            tm -= Time.deltaTime;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && tm <= 0 && HitBox.IsTouching(other)) 
        {
            tm = Cooldown;
            Health--;
        }
    }


}
