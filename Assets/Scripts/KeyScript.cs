using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour {

	public AudioClip soundKey;
	public int speed = 300;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			
			StartCoroutine (takeKey ());
		}
	}

	void Update(){
		transform.Rotate (Vector3.up * speed * Time.deltaTime);
	}

	IEnumerator takeKey(){
		
		GetComponent<AudioSource> ().PlayOneShot (soundKey);
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().locked = false;
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.SetActive (true);
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().panelText.transform.Find ("Text").GetComponent<Text>().text = "FIND THE EXIT NOW";
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().hideTextPanel ();
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);

	}
}
