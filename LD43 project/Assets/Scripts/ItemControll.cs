using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControll : MonoBehaviour {

    public Weapons[] weapon;
    public GameObject Sword;
    public GameObject Spear;
    public GameObject Bow;
    public GameObject BowControll;


    public GameObject Arrow;

    public GameObject[] HitBoxes;

	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int slot = player.GetComponent<InventoryC>().slot;
        int type;
        if (weapon[slot] != null)
        {
            type = (int)weapon[slot]._type;
        }
        else
        {
            type = -1;
        }
        switch (type)
        {
            case (0):
                BowControll.GetComponent<PlayerAttackBow>().damage = weapon[slot].Damage;
                BowControll.GetComponent<PlayerAttackBow>().knockback = weapon[slot].Knockback;
                BowControll.GetComponent<PlayerAttackBow>().element = (int)weapon[slot].element;

                Bow.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                break;
            case (1):
                Sword.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                HitBoxes[0].GetComponent<HitboxControll>().Damage = weapon[slot].Damage;
                HitBoxes[0].GetComponent<HitboxControll>().Knockback = weapon[slot].Knockback;
                HitBoxes[0].GetComponent<HitboxControll>().Element = (int)weapon[slot].element;
                break;
            case (2):
                Spear.GetComponent<SpriteRenderer>().sprite = weapon[slot].sprite;
                HitBoxes[1].GetComponent<HitboxControll>().Damage = weapon[slot].Damage;
                HitBoxes[1].GetComponent<HitboxControll>().Knockback = weapon[slot].Knockback;
                HitBoxes[1].GetComponent<HitboxControll>().Element = (int)weapon[slot].element;
                break;
        }
    }
}
