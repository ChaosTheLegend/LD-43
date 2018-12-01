using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToArray : MonoBehaviour {

    private Templates temp;
	// Use this for initialization
	void Start () {
		temp = GameObject.FindGameObjectWithTag("Template").GetComponent<Templates>();
        temp.Rooms.Add(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
