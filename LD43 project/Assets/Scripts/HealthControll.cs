using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControll : MonoBehaviour {
    public int Health;
    public float Cooldown;
    public float tm;
    public Collider2D HitBox;
    public GameObject DeathEffect;
    public GameObject DeadPanel;
    bool dead = false;
    private void Update()
    {
        if (tm > 0)
        {
            tm -= Time.deltaTime;
        }

        
    }
    void Dead()
    {
        DeadPanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && tm <= 0 && HitBox.IsTouching(other)) 
        {
            tm = Cooldown;
            Health--;
            FindObjectOfType<AudioManager>().Play("PlayerHit");
        }
        if (!dead && Health <= 0)
        {
            GetComponent<CharacterMovement>().active = false;
            Instantiate(DeathEffect, transform.position, transform.rotation);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Invoke("Dead",1f);
            dead = true;
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
        }
    }


}
