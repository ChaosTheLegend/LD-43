using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour {

    public bool active = false;
	void Update () {
        GameObject[] Enemies = new GameObject[transform.childCount];
        if (Enemies.Length > 0)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i] = transform.GetChild(i).gameObject;
                Enemies[i].GetComponent<EnemyMovement>().active = active;
            }
        }

	}
}
