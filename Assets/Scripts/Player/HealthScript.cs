using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

	public int Hp = 100;
	public AudioClip DeathSound;

	private bool alive = true;

	// Use this for initialization
	void Start ()
    {
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (Hp);
	}

	public void DamagePlayer(int damages)
    {
		Hp -= damages;
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (Hp);

		if (Hp <= 0 && alive)
        {
			alive = false;

			GetComponent<AudioSource> ().PlayOneShot (DeathSound);
			transform.Find("FirstPersonCharacter").GetComponent<PlayerDeathScript> ().PlayAnimDead ();
			GameObject.Find ("FPSController").GetComponent<CharacterController> ().enabled = false;
			GameObject.Find ("Bloodblur").GetComponent<Image> ().enabled = true;

			for (int i = 0; i < transform.childCount; i++)
            {
				transform.GetChild (i).gameObject.SetActive (false);
			}

			GameObject[] ennemies = GameObject.FindGameObjectsWithTag ("ennemy");

			foreach (GameObject e in ennemies)
            {
				e.GetComponent<AudioSource> ().enabled = false;
			}

			StartCoroutine (ReloadScene ());
		}
	}

	IEnumerator ReloadScene()
    {
		yield return new WaitForSeconds (3f);

		SceneManager.LoadScene ("Menu");
	}

	public void AddHealth(int heal)
    {

		Hp += heal;
		GameObject.Find ("PanelUI").GetComponent<UIScript> ().UpdateLife (Hp);

	}
}
