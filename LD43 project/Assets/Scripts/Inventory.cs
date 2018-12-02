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
    bool inv1open = false;
    bool inv2open = false;
    bool inv3open = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1") && inv1open == false)
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
        if (Input.GetKeyDown("2") && inv2open == false)
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
            inv2open = false;
            inv1open = true;
            inv3open = true;

        }
        if (Input.GetKeyDown("3") && inv3open == false)
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
            inv3open = false;
            inv2open = true;
            inv1open = true;

        }
    }
}
