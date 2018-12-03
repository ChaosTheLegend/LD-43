using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour {
    public Image[] Slots;
    public Image Health;
    public Sprite[] HPStates;


    // Update is called once per frame
    void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject RotatingThing = player.GetComponent<InventoryC>().RotatingThing;
        int hp = player.GetComponent<HealthControll>().Health;

        try
        {
            if (hp > 0)
            {
                Health.sprite = HPStates[hp - 1];
            }
            Slots[0].sprite = RotatingThing.GetComponent<ItemControll>().weapon[0].sprite;
            Slots[1].sprite = RotatingThing.GetComponent<ItemControll>().weapon[1].sprite;
            Slots[2].sprite = RotatingThing.GetComponent<ItemControll>().weapon[2].sprite;
        }
        catch { }

    }
}
