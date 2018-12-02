using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {
    bool inv1o;
    bool inv2o;
    bool inv3o;
    string name;
	// Use this for initialization
	void Start () {
        if (gameObject.name[0].ToString() == "b")
        {
            name = "bowTemp(Clone)";
        }
        if (gameObject.name[0].ToString() == "s")
        {
            name = "swordTemp(Clone)";
        }
        if (gameObject.name[1].ToString() == "p")
        {
            name = "spearTemp(Clone)";
        }
        print(name);
    }
	
	// Update is called once per frame
	void Update () {
        inv1o = Inventory.inv1open;
        inv2o = Inventory.inv2open;
        inv3o = Inventory.inv2open;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (inv1o == true) {
            //Inventory.inv1 = name;
        }
        if (inv2o == true)
        {
            //Inventory.inv2 = name;
        }
        if (inv2o == true)
        {
            //Inventory.inv3 = name;
        }
    }
}
