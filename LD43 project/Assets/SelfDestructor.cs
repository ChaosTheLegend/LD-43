using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    public float Lifetime;
    void Update () {
        if (Lifetime <= 0)
        {
            Destroy(gameObject);
        }
        Lifetime -= Time.deltaTime;
	}
}
