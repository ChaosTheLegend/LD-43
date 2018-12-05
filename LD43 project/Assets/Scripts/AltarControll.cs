using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarControll : MonoBehaviour {

    public bool sacrifice = false;
    public Weapons item;
    public bool usable = false;
    public SpriteRenderer weapon;
    bool heal = false;

    public GameObject ShineEffect;
    public GameObject[] BeamEffect;
	void Update () {
        if (sacrifice)
        {
            weapon.sprite = item.sprite;
            weapon.color = new Color(1, 1, 1, 1);
            ShineEffect.SetActive(false);
            BeamEffect[(int)item.element].SetActive(true);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (!heal)
            {
                player.GetComponent<HealthControll>().Health = 3;
                heal = true;
            }
        }
        else
        {
            weapon.color = new Color(1, 1, 1, 0);
        }
        if (usable && !sacrifice)
        {
            ShineEffect.SetActive(true);
        }
	}
}
