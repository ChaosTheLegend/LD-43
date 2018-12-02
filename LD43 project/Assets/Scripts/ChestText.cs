using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyObject", 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
