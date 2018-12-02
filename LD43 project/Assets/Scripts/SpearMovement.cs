using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMovement : MonoBehaviour {

    public Animator SpearAnim;
    public GameObject HitBox;
    public AnimationClip AttackState;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            SpearAnim.SetBool("Atk",true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            SpearAnim.SetBool("Atk", false);
        }
        try
        {
            if (SpearAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name == AttackState.name)
            {
                HitBox.SetActive(true);
            }
            else
            {
                HitBox.SetActive(false);
            }
        }
        catch { }

	}
}
