using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            Destroy(other.gameObject);
        }
    }
}
