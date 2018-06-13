using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

	public GameObject[] weapons;

	public int currentWeapon = 0;
	public float delay = 1f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < weapons.Length; i++) {
			if (i != currentWeapon) {
				weapons [i].SetActive (false);
			} else {
				weapons [i].SetActive (true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			int nextWeapon = (currentWeapon + 1) % weapons.Length;
			StartCoroutine (changeWeapon (currentWeapon, nextWeapon));
			currentWeapon = nextWeapon;

		}
	}

	IEnumerator changeWeapon(int currentWeapon, int newWeapon){
		GameObject current = weapons [currentWeapon];

		current.GetComponent<Animator> ().SetTrigger ("out");
		yield return new WaitForSeconds (delay);
		current.SetActive (false);
		weapons [newWeapon].SetActive (true);

	}
}
