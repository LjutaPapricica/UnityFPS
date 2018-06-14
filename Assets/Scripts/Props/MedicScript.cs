using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicScript : MonoBehaviour {

	public AudioClip soundMedic;
	public int medicPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			StartCoroutine (AddMedicPlayer());
		}
	}

	IEnumerator AddMedicPlayer(){
		GetComponent<AudioSource> ().PlayOneShot (soundMedic);
		GameObject.Find ("FPSController").GetComponent<HealthScript> ().addHealth (medicPoint);
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
