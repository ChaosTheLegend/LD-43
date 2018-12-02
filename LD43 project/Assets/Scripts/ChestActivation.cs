using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestActivation : MonoBehaviour {
    public GameObject chestText;
    public GameObject WeaponTemplate;
    public Weapons Contance;
    public bool opened = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        {
            chestText.SetActive(false);
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            chestText.SetActive(true);
        }
    }
    void OnMouseDown()
    {
        if (!opened)
        {
            GameObject obj = Instantiate(WeaponTemplate, transform.position + new Vector3(0, -0.9f, 0), Quaternion.identity);
            obj.GetComponent<DropControll>().item = Contance;
            opened = true;
        }
    }
}
