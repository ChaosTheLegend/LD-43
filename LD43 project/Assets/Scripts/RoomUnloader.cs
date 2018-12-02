using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnloader : MonoBehaviour {

    public float len;
    public bool generated = false;
    // Update is called once per frame
    void Update() {

        if (generated)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var dis = transform.position - player.transform.position;
            len = dis.magnitude;
            if (len >= 40f)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
	}
}
