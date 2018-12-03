﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint") || other.CompareTag("Blocker"))
        {
            Destroy(other.gameObject);
        }
    }
}
