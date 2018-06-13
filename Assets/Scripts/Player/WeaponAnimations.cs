using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour {

	private Animator anim;
	public Animator animFlame;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Tir tir = GetComponent<Tir> ();

		if (tir.isAuto) {
			
			if (Input.GetButton ("Fire1")) {
				fireAnim (tir);
			}

		} else {
			
			if (Input.GetButtonDown ("Fire1")) {
				fireAnim (tir);
			}

		}


		if (Input.GetKeyDown (KeyCode.R)) {
			tir = GetComponent<Tir> ();
			if (tir.rounds < tir.max_rounds && tir.magazines > 0) {
				anim.SetTrigger ("reload");
			}
		}

		if ((Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) && !Input.GetButton("Fire3")) {
			anim.SetBool ("walking", true);
			anim.SetBool ("running", false);
		} else {
			anim.SetBool ("walking", false);
		}

		if (Input.GetAxis ("Vertical") != 0 && Input.GetButton("Fire3")) {
			anim.SetBool ("walking", false);
			anim.SetBool ("running", true);
		} else {
			anim.SetBool ("running", false);
		}

	}

	void fireAnim(Tir tir){
		if (tir.canFire) {
			if (tir.rounds > 0) {
				anim.SetTrigger ("fire");
				animFlame.SetTrigger ("flame");
			}
		}
	}
}
