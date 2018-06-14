using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{

	public AudioClip Soundwin;

	void OnTriggerEnter (Collider col)
    {
		if (col.gameObject.tag == "Player")
        {
			bool locked = GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().Locked;
			if (locked)
            {
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.SetActive (true);
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.transform.Find ("Text").GetComponent<Text>().text = "DOOR IS LOCKED";
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().HideTextPanel ();
			}
            else
            {
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.SetActive (true);
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().PanelText.transform.Find ("Text").GetComponent<Text>().text = "MISSION ACCOMPLISHED";
				GameObject.Find ("CanvasMission").GetComponent<MissionScript> ().HideTextPanel ();

				GetComponent<AudioSource> ().PlayOneShot (Soundwin);
				StartCoroutine (EndLevel ());
			}
		}
	}

	IEnumerator EndLevel()
    {
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Menu");
	}

}
