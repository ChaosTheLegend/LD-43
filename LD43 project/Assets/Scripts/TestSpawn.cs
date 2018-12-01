using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour {
    public GameObject Enemy;
	// Use this for initialization
	void Start () {
        Spawn();
        InvokeRepeating("Spawn", 5, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
