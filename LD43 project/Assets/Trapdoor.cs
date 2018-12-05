using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour {
    public GameObject Altar;
    public bool open;
    public Sprite OpenSpr;
    void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject template = GameObject.FindGameObjectWithTag("Template");
       
        open = Altar.GetComponent<AltarControll>().sacrifice;

        if (open)
        {
            GetComponent<SpriteRenderer>().sprite = OpenSpr;
            if (Vector3.Distance(transform.position, player.transform.position) <= 1f)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    template.GetComponent<Templates>().cleared = true;
                }
            }
        }
	}
}
