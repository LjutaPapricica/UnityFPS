using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{

	private Animator anim;
	public Animator AnimFlame;

	// Use this for initialization
	void Start ()
    {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		Tir tir = GetComponent<Tir> ();

		if (tir.IsAuto)
        {
			
			if (Input.GetButton ("Fire1"))
            {
				FireAnim (tir);
			}

		}
        else
        {
			
			if (Input.GetButtonDown ("Fire1"))
            {
				FireAnim (tir);
			}

		}


		if (Input.GetKeyDown (KeyCode.R))
        {
			tir = GetComponent<Tir> ();

			if (tir.Rounds < tir.MaxRounds && tir.Magazines > 0)
            {
				anim.SetTrigger ("reload");
			}
		}

		if ((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) && !Input.GetButton("Fire3"))
        {
			anim.SetBool ("walking", true);
			anim.SetBool ("running", false);
		}
        else
        {
			anim.SetBool ("walking", false);
		}

		if (Input.GetAxis ("Vertical") != 0 && Input.GetButton("Fire3"))
        {
			anim.SetBool ("walking", false);
			anim.SetBool ("running", true);

		}
        else
        {
			anim.SetBool ("running", false);
		}

	}

	void FireAnim(Tir tir)
    {
		if (tir.CanFire)
        {
			if (tir.Rounds > 0)
            {
				anim.SetTrigger ("fire");
				AnimFlame.SetTrigger ("flame");
			}
		}
	}
}
