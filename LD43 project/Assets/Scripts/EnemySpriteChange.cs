using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteChange : MonoBehaviour {
    public Sprite earth;
    public Sprite fire;
    public Sprite water;
    public int rand;
    private SpriteRenderer spriteR;
    // Use this for initialization
    void Start () {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        rand = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
        if (rand <= 1)
        {
            spriteR.sprite = earth;
        }
        if (rand == 2)
        {
            spriteR.sprite = fire;
        }
        if (rand >= 3)
        {
            spriteR.sprite = water;
        }
    }
}
