using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public GameObject player;
    public GameObject bow;
    public GameObject sword;
    public GameObject spear;
    public string inv1;
    public string inv2;
    public string inv3;
    static public bool inv1open;
    static public bool inv2open;
    static public bool inv3open;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        inv1open = true;
        inv2open = true;
        inv3open = true;
}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1") && inv1open == true)
        {
            if (inv1 == "Bow")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));         
                Instantiate(bow, transform.position, Quaternion.identity);
            }
            if (inv1 == "Sword")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(sword, transform.position, Quaternion.identity);
            }
            if (inv1 == "Spear")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(spear, transform.position, Quaternion.identity);
            }
            inv1open = false;
            inv2open = true;
            inv3open = true;

        }
        if (Input.GetKeyDown("2") && inv2open == true)
        {
            if (inv2 == "Bow")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(bow, transform.position, Quaternion.identity);
            }
            if (inv2 == "Sword")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(sword, transform.position, Quaternion.identity);
            }
            if (inv2 == "Spear")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(spear, transform.position, Quaternion.identity);
            }
            inv2open = false;
            inv1open = true;
            inv3open = true;

        }
        if (Input.GetKeyDown("3") && inv3open == true)
        {
            if (inv3 == "Bow")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(bow, transform.position, Quaternion.identity);
            }
            if (inv3 == "Sword")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(sword, transform.position, Quaternion.identity);
            }
            if (inv3 == "Spear")
            {
                Destroy(GameObject.Find("BowTemp(Clone)"));
                Destroy(GameObject.Find("SwordTemp(Clone)"));
                Destroy(GameObject.Find("SpearTemp(Clone)"));
                Instantiate(spear, transform.position, Quaternion.identity);
            }
            inv3open = false;
            inv2open = true;
            inv1open = true;

        }
    }
}
