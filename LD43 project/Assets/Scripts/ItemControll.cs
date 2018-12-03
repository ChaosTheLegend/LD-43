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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int slot = player.GetComponent<InventoryC>().slot;

        int type = (int)weapon[slot]._type;
        switch (type)
        {
            case (0):
                Bow.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                break;
            case (1):
                Sword.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                break;
            case (2):
                Spear.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                break;
        }

        HitBoxes[0].GetComponent<HitboxControll>().Damage = weapon[0].Damage;
        HitBoxes[0].GetComponent<HitboxControll>().Knockback = weapon[0].Knockback;
        HitBoxes[0].GetComponent<HitboxControll>().Element = (int)weapon[0].element;

        HitBoxes[1].GetComponent<HitboxControll>().Damage = weapon[1].Damage;
        HitBoxes[1].GetComponent<HitboxControll>().Knockback = weapon[1].Knockback;
        HitBoxes[1].GetComponent<HitboxControll>().Element = (int)weapon[1].element;


    }
}
