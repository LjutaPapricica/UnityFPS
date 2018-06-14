using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : MonoBehaviour
{

	public GameObject PanelText;
	public bool Locked; 

	// Use this for initialization
	void Start ()
    {
		HideTextPanel ();
	}

	public void HideTextPanel ()
    {
		StartCoroutine (HidePanel ());
	}

	IEnumerator HidePanel()
    {
		yield return new WaitForSeconds (10f);
		PanelText.SetActive (false);
	}
}
