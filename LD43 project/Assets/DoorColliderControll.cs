using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColliderControll : MonoBehaviour {

    public bool up;
	void Update () {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<DoorStateMachine>().up = up;
        }
        GetComponent<Rigidbody2D>().simulated = up;

    }
}
