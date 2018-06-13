using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour {

	public int hp = 100;
	public AudioClip deathSound;
	private bool alive = true;

	// Use this for initialization
	void Start () {
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (hp);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void damagePlayer(int damages){
		hp -= damages;
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (hp);

		if (hp <= 0 && alive) {
			alive = false;
			GetComponent<AudioSource> ().PlayOneShot (deathSound);
			transform.Find("FirstPersonCharacter").GetComponent<PlayerDeathScript> ().playAnimDead ();
			GameObject.Find ("FPSController").GetComponent<CharacterController> ().enabled = false;
			GameObject.Find ("Bloodblur").GetComponent<Image> ().enabled = true;
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).gameObject.SetActive (false);
			}

			GameObject[] ennemies = GameObject.FindGameObjectsWithTag ("ennemy");

			foreach (GameObject e in ennemies) {
				e.GetComponent<AudioSource> ().enabled = false;
			}

			StartCoroutine (reloadScene ());
		}
	}

	IEnumerator reloadScene(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("Menu");
	}

	public void addHealth(int heal){
		hp += heal;
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (hp);
	}
}
