using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathControll : MonoBehaviour {

    public Transform[] points;
	// Use this for initialization
	void Start () {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }


	}
	
}
