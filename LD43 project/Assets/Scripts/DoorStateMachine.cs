using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStateMachine : MonoBehaviour {

    public bool up;
    public Animator anim;
	void Update () {
        anim.SetBool("Up", up);
	}
}
