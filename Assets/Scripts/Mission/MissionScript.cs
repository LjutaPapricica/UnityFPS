using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : MonoBehaviour {

	public GameObject panelText;
	public bool locked; 

	// Use this for initialization
	void Start () {
		hideTextPanel ();
	}

	public void hideTextPanel () {
		StartCoroutine (hidePanel ());
	}

	IEnumerator hidePanel(){
		yield return new WaitForSeconds (10f);
		panelText.SetActive (false);
	}
}
