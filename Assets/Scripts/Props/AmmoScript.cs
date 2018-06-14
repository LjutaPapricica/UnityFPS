using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{

	public AudioClip SoundAmmo;
	public int NbMags;

	void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.tag == "Player")
        {
			StartCoroutine (AddMagsPlayer());
		}
	}

	IEnumerator AddMagsPlayer()
    {

		GetComponent<AudioSource> ().PlayOneShot (SoundAmmo);

		int iTab = GameObject.Find ("FPSController").GetComponent<WeaponManager> ().CurrentWeapon;

		GameObject weapon = GameObject.Find ("FPSController").GetComponent<WeaponManager> ().Weapons [iTab];
		weapon.GetComponent<Tir> ().AddMagazines (NbMags);

		yield return new WaitForSeconds (0.5f);

		Destroy (gameObject);

	}
}
