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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 dis = transform.position - player.transform.position;
            float len = dis.magnitude;
            if (len < 2f && !opened)
            {
                    chestText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject obj = Instantiate(WeaponTemplate, transform.position + new Vector3(0, -1.3f, 0), Quaternion.identity);
                        obj.GetComponent<DropControll>().item = Contance;
                        opened = true;
                    }
            }
            else
            {
                chestText.SetActive(false);
            }
        }

    }
}
