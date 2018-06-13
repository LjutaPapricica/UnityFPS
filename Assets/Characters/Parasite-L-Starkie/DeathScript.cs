using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathScript : MonoBehaviour {

	private Animator animator;
	public GameObject ennemyAudio;
	public AudioClip deathSound;
	private bool dying = false;
	public int hp = 100;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (dying){
			float x, y;
			x = GetComponent<CapsuleCollider> ().center.x;
			y = GetComponent<CapsuleCollider> ().center.y;
			GetComponent<CapsuleCollider>().center = new Vector3(x, y, animator.GetFloat("ColCurve"));
		}

	}

	public void death(int damages){
		Debug.Log ("HIT");
		if (hp <= 0) {
			Debug.Log ("KILL");
			die ();
		} else {
			Debug.Log("Damage");
			hp -= damages;
			ennemyAudio.GetComponent<AudioSource> ().PlayOneShot (deathSound);
		}

	}

	public void die(){
		dying = true;
		GetComponent<Rigidbody> ().isKinematic = false;
		ennemyAudio.GetComponent<AudioSource> ().Stop ();
		ennemyAudio.GetComponent<AudioSource> ().PlayOneShot (deathSound);
		animator.SetTrigger ("dead");
		animator.SetBool ("attack", false);
		GetComponent<IAParasite> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
		//GetComponent<CapsuleCollider> ().enabled = false;
		Destroy (gameObject, 10f);
	}

	public bool isDying(){
		return this.dying;
	}

	public void activationIsKinematic(){
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
