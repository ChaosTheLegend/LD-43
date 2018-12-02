using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

    public Animator SwordAnim;
    public AnimationClip AtkState;
    public GameObject HitBox;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SwordAnim.SetBool("Atk", true);
        }
        else
        {
            SwordAnim.SetBool("Atk", false);
        }

        if (SwordAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name == AtkState.name)
        {
            HitBox.SetActive(true);
        }
        else
        {
            HitBox.SetActive(false);
        }
    }
}
