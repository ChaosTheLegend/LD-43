using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void Update()
    {
        GameObject[] Rooms = GameObject.FindGameObjectsWithTag("Room");
        float len = 1000f;

        foreach (GameObject rm in Rooms)
        {
            Vector3 dis = transform.position - rm.transform.position;
            if (dis.magnitude < len)
            {
                len = dis.magnitude;
            }
        }

        if (len < 10f)
        {
            Destroy(gameObject);
        }

    }
}
