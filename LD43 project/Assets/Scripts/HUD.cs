using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HUD : MonoBehaviour {
    public Image[] Slots;
    public Image[] SlotBackgorund;
    public Image Health;
    public Sprite[] HPStates;
    public Sprite SlotEmpty;
    public Sprite SlotFull;
    public Sprite SlotActive;



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
            if (hp <= 0)
            {
                SceneManager.LoadScene("Game");
                hp = 3;
            }
            for (int i = 0; i < 3; i++)
            {
                if (RotatingThing.GetComponent<ItemControll>().weapon[i] != null)
                {
                    Slots[i].sprite = RotatingThing.GetComponent<ItemControll>().weapon[i].sprite;
                    SlotBackgorund[i].sprite = SlotFull;
                    Slots[i].color = new Color(1, 1, 1, 1);
                }
                else
                {
                    SlotBackgorund[i].sprite = SlotEmpty;
                    Slots[i].color = new Color(1, 1, 1, 0);
                }
                
                int slot = player.GetComponent<InventoryC>().slot;
                SlotBackgorund[slot].sprite = SlotActive;
                
            }
        }
        catch { }

    }
}
