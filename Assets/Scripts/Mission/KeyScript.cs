using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{

	public AudioClip SoundKey;
	public int Speed = 300;

	void OnTriggerEnter(Collider col)
    {
		if(col.gameObject.tag == "Player")
        {
			
			StartCoroutine (TakeKey ());
		}
	}

	void Update()
    {
		transform.Rotate (Vector3.up * Speed * Time.deltaTime);
	}

	IEnumerator TakeKey()
    {
		
		GetComponent<AudioSource> ().PlayOneShot (SoundKey);
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().Locked = false;
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.SetActive (true);
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.transform.Find ("Text").GetComponent<Text>().text = "FIND THE EXIT NOW";
		GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().HideTextPanel ();
		yield return new WaitForSeconds (0.5f);
		Destroy (gameObject);

	}
}
