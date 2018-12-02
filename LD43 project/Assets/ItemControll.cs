using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControll : MonoBehaviour {

    public Weapons[] weapon;
    public GameObject Sword;
    public GameObject Spear;
    public GameObject Bow;
    public GameObject Arrow;
	
	// Update is called once per frame
	void Update () {
        Sword.GetComponent<SpriteRenderer>().sprite = weapon[0].sprite;
        Spear.GetComponent<SpriteRenderer>().sprite = weapon[1].sprite;
        Bow.GetComponent<SpriteRenderer>().sprite = weapon[2].sprite;
    }
}
