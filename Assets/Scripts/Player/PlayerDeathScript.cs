using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{

	Animator Anim;

	// Use this for initialization
	void Start ()
    {
		Anim = GetComponent<Animator> ();
	}
	
	public void PlayAnimDead()
    {
		Anim.enabled = true;
	}
}
