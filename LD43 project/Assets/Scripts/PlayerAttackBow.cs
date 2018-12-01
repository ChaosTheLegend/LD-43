using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBow : MonoBehaviour {
    public Rigidbody2D arrow;
    public GameObject player;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(arrow, player.transform.position, Quaternion.identity);
        }

    }
}
