using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryC : MonoBehaviour {
    public GameObject player;
    public GameObject bow;
    public GameObject sword;
    public GameObject spear;
    public string inv1;
    public string inv2;
    public string inv3;
    bool inv1open = true;
    bool inv2open = true;
    bool inv3open = true;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1") && inv1open == true)
        {
            if (inv1 == "Bow")
            {
                bow.SetActive(true);
                sword.SetActive(false);
                spear.SetActive(false);

            }
            if (inv1 == "Sword")
            {
                bow.SetActive(false);
                sword.SetActive(true);
                spear.SetActive(false);
            }
            if (inv1 == "Spear")
            {
                bow.SetActive(false);
                sword.SetActive(false);
                spear.SetActive(true);
            }
            inv1open = false;
            inv2open = true;
            inv3open = true;

        }
        if (Input.GetKeyDown("2") && inv2open == true)
        {
            if (inv2 == "Bow")
            {
                bow.SetActive(true);
                sword.SetActive(false);
                spear.SetActive(false);
            }
            if (inv2 == "Sword")
            {
                bow.SetActive(false);
                sword.SetActive(true);
                spear.SetActive(false);
            }
            if (inv2 == "Spear")
            {
                bow.SetActive(false);
                sword.SetActive(false);
                spear.SetActive(true);
            }
            inv2open = false;
            inv1open = true;
            inv3open = true;

        }
        if (Input.GetKeyDown("3") && inv3open == true)
        {
            if (inv3 == "Bow")
            {
                bow.SetActive(true);
                sword.SetActive(false);
                spear.SetActive(false);
            }
            if (inv3 == "Sword")
            {
                bow.SetActive(false);
                sword.SetActive(true);
                spear.SetActive(false);
            }
            if (inv3 == "Spear")
            {
                bow.SetActive(false);
                sword.SetActive(false);
                spear.SetActive(true);
            }
            inv3open = false;
            inv2open = true;
            inv1open = true;

        }
    }
}
