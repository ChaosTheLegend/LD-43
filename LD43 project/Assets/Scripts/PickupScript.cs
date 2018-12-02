using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {
    bool inv1o;
    bool inv2o;
    bool inv3o;
    string inv1;
	// Use this for initialization
	void Start () {
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
            
        }
    }
}
