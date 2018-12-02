using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControll : MonoBehaviour {

    public Weapons[] weapon;
    public GameObject Sword;
    public GameObject Spear;
    public GameObject Bow;
    public GameObject Arrow;

    public GameObject[] HitBoxes;

	// Update is called once per frame
	void Update () {
        Sword.GetComponent<SpriteRenderer>().sprite = weapon[0].sprite;
        Spear.GetComponent<SpriteRenderer>().sprite = weapon[1].sprite;
        Bow.GetComponent<SpriteRenderer>().sprite = weapon[2].sprite;

        HitBoxes[0].GetComponent<HitboxControll>().Damage = weapon[0].Damage;
        HitBoxes[0].GetComponent<HitboxControll>().Knockback = weapon[0].Knockback;
        HitBoxes[0].GetComponent<HitboxControll>().Element = (int)weapon[0].element;

        HitBoxes[1].GetComponent<HitboxControll>().Damage = weapon[1].Damage;
        HitBoxes[1].GetComponent<HitboxControll>().Knockback = weapon[1].Knockback;
        HitBoxes[1].GetComponent<HitboxControll>().Element = (int)weapon[1].element;


    }
}
