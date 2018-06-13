using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour {

	public AudioClip soundAmmo;
	public int nbMags;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			StartCoroutine (AddMagsPlayer());
		}
	}

	IEnumerator AddMagsPlayer(){
		GetComponent<AudioSource> ().PlayOneShot (soundAmmo);
		int iTab = GameObject.Find ("FPSController").GetComponent<WeaponManager> ().currentWeapon;
		GameObject weapon = GameObject.Find ("FPSController").GetComponent<WeaponManager> ().weapons [iTab];
		weapon.GetComponent<Tir> ().AddMagazines (nbMags);
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
