using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBow : MonoBehaviour {
    public GameObject arrow;
    public Transform ArrowSpawner;

    public float damage;
    public float knockback;
    public int element;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ar = Instantiate(arrow, ArrowSpawner.transform.position, ArrowSpawner.transform.rotation).gameObject;
            ar.GetComponent<HitboxControll>().Damage = damage;
            ar.GetComponent<HitboxControll>().Knockback = knockback;
            ar.GetComponent<HitboxControll>().Element = element;

        }

    }
}
