using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	public AudioClip soundShoot;
	public AudioClip soundReload;
	public AudioClip soundEmpty;
	private Ray ray;
	private RaycastHit hit;
	public GameObject bulletHolePrefab;
	public GameObject sparksPrefab;
	public float fireRate = 1;
	private float nextFire;
	public int rounds, max_rounds;
	public int magazines;
	public bool isAuto = true, canFire = false;
	private GameObject PanelUI;
	public int weaponDamages;
	public int maxMags;


	//For animation script
	public float getNextFire(){
		return this.nextFire;
	}

	// Use this for initialization
	void Start () {
		PanelUI = GameObject.Find ("PanelUI");
		Debug.Log (PanelUI);
		PanelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (rounds, max_rounds, magazines);
	}

	void OnEnable(){
		PanelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (rounds, max_rounds, magazines);
	}

	void Update () {

		if (Time.time > nextFire) {
			canFire = true;
		} else {
			canFire = false;
		}

		if (isAuto) {

			if (Input.GetButton ("Fire1")) {
				fire ();
			}

		} else {

			if (Input.GetButtonDown ("Fire1")) {
				fire ();
			}


		}



		if (Input.GetButtonDown ("Fire1") && rounds == 0) {
			GetComponent<AudioSource> ().PlayOneShot (soundEmpty);
		}

		if (Input.GetKeyDown (KeyCode.R) && magazines > 0 && rounds < max_rounds) {

			GetComponent<AudioSource> ().PlayOneShot (soundReload);
			StartCoroutine (Reload ());

		}
	}

	IEnumerator Reload(){
		yield return new WaitForSeconds (0.2f);
		magazines -= 1;
		rounds = max_rounds;
		PanelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (rounds, max_rounds, magazines);
	}

	void fire(){
		if (canFire) { //Fire rate
			if (rounds > 0) {

				rounds--;
				PanelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (rounds, max_rounds, magazines);
				nextFire = Time.time + fireRate;
				GetComponent<AudioSource> ().PlayOneShot (soundShoot);

				//Get screen center as raycast target
				Vector2 screenCenterPoint = new Vector2 (Screen.width / 2, Screen.height / 2);
				ray = Camera.main.ScreenPointToRay (screenCenterPoint);
				if (Physics.Raycast (ray, out hit, Camera.main.farClipPlane)) {
					if (hit.transform.gameObject.tag == "target") {
						Destroy (hit.transform.gameObject);
					}
					if (hit.transform.gameObject.tag == "ennemy") {
						if (!hit.transform.gameObject.GetComponent<DeathScript> ().isDying ()) {
							hit.transform.gameObject.GetComponent<DeathScript> ().death (weaponDamages);
						}

					}
					if (hit.transform.gameObject.tag == "decors") {

						//Bullet hole
						GameObject Impact;
						Impact = Instantiate (bulletHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
						Destroy (Impact, 20f);

						//Sparks
						GameObject Sparks = Instantiate(sparksPrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
						Destroy (Sparks, 3f);
					}
				}
			}
		}
	}

	public void AddMagazines(int nbMags){
		magazines = Mathf.Min(nbMags + magazines, maxMags);
		PanelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (rounds, max_rounds, magazines);
	}
}
