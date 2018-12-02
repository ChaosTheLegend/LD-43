using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBow : MonoBehaviour {
    public Rigidbody2D arrow;
    public Transform ArrowSpawner;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(arrow, ArrowSpawner.transform.position, ArrowSpawner.transform.rotation);
        }

    }
}
