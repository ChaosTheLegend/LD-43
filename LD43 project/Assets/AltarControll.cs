using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarControll : MonoBehaviour {

    public bool sacrifice = false;
    public Weapons item;
    public SpriteRenderer weapon;
	void Update () {
        if (sacrifice)
        {
            weapon.sprite = item.sprite;
            weapon.color = new Color(1, 1, 1, 1);
        }
        else
        {
            weapon.color = new Color(1, 1, 1, 0);
        }
	}
}
