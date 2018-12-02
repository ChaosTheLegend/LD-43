using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropControll : MonoBehaviour {

    public Weapons item;
    public SpriteRenderer sprite;

	void Update () {
        sprite.sprite = item.sprite;		
	}
}
