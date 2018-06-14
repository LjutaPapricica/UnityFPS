using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

	public GameObject[] Weapons;

	public int CurrentWeapon = 0;
	public float Delay = 1f;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Weapons.Length; i++)
        {
			if (i != CurrentWeapon)
            {
				Weapons [i].SetActive (false);
			}
            else
            {
				Weapons [i].SetActive (true);
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown (KeyCode.Tab))
        {
			int nextWeapon = (CurrentWeapon + 1) % Weapons.Length;
			StartCoroutine (ChangeWeapon (CurrentWeapon, nextWeapon));
			CurrentWeapon = nextWeapon;

		}
	}

	IEnumerator ChangeWeapon(int currentWeapon, int newWeapon)
    {
		GameObject current = Weapons [currentWeapon];
		current.GetComponent<Animator> ().SetTrigger ("out");

		yield return new WaitForSeconds (Delay);

		current.SetActive (false);
		Weapons [newWeapon].SetActive (true);

	}
}
