using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	public AudioClip soundwin;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Player") {
			bool locked = GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().locked;
			if (locked) {
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.SetActive (true);
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.transform.Find ("Text").GetComponent<Text>().text = "DOOR IS LOCKED";
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().hideTextPanel ();
			} else {
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.SetActive (true);
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.transform.Find ("Text").GetComponent<Text>().text = "MISSION ACCOMPLISHED";
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().hideTextPanel ();
				GetComponent<AudioSource> ().PlayOneShot (soundwin);
				StartCoroutine (endLevel ());
			}
		}
	}

	IEnumerator endLevel(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Menu");

	}

}
