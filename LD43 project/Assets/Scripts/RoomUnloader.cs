using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnloader : MonoBehaviour {

    public float len;
    public bool generated = false;
    // Update is called once per frame
    void Update() {

        if (generated && GameObject.FindGameObjectWithTag("Template").GetComponent<Templates>().generated)
        {
            RoomControll RoomC = GetComponent<RoomControll>();
            GameObject RoomLayout = RoomC.Layout;
            GameObject Enemies = RoomC.Enemies;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var dis = transform.position - player.transform.position;
            len = dis.magnitude;
            if (len >= 40f)
            {
                RoomLayout.SetActive(false);
                Enemies.SetActive(false);
            }
            else
            {
                RoomLayout.SetActive(true);
                Enemies.SetActive(true);
            }
        }
	}
}
