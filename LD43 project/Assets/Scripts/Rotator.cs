using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    float angle = 0;
	void Update () {
        angle+= 3;
        GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -angle);
        if (angle > 360)
        {
            angle -= 360;
        }
    }
}
