using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicScript : MonoBehaviour
{

	public AudioClip SoundMedic;
    
	public int MedicPoint;

	void OnTriggerEnter(Collider col)
    {

		if (col.gameObject.tag == "Player")
        {
			StartCoroutine (AddMedicPlayer());
		}
	}

	IEnumerator AddMedicPlayer()
    {

		GetComponent<AudioSource> ().PlayOneShot (SoundMedic);
		GameObject.Find ("FPSController").GetComponent<HealthScript> ().AddHealth (MedicPoint);
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);
	}
}
