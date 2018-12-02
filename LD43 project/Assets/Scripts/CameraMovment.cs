using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour {
    public GameObject player;
    public float x;
    public float y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        x = player.transform.position.x;
        y = player.transform.position.y;
        transform.position = new Vector3(x, y, -10);
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }
}
