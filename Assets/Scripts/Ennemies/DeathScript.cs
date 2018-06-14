using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathScript : MonoBehaviour
{

	
	public GameObject EnnemyAudio;
	public AudioClip DeathSound;
	public int Hp = 100;

    private bool dying = false;
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (dying)
        {
			float x, y;
			x = GetComponent<CapsuleCollider> ().center.x;
			y = GetComponent<CapsuleCollider> ().center.y;
			GetComponent<CapsuleCollider>().center = new Vector3(x, y, animator.GetFloat("ColCurve"));
		}

	}

	public void Death(int damages)
    {
		Debug.Log ("HIT");
		if (Hp <= 0)
        {
			Debug.Log ("KILL");
			Die ();
		}
        else
        {
			Debug.Log("Damage");
			Hp -= damages;
			EnnemyAudio.GetComponent<AudioSource> ().PlayOneShot (DeathSound);
		}

	}

	public void Die()
    {
		dying = true;
		GetComponent<Rigidbody> ().isKinematic = false;
		EnnemyAudio.GetComponent<AudioSource> ().Stop ();
		EnnemyAudio.GetComponent<AudioSource> ().PlayOneShot (DeathSound);
		animator.SetTrigger ("dead");
		animator.SetBool ("attack", false);
		GetComponent<IAParasite> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
		//GetComponent<CapsuleCollider> ().enabled = false;
		Destroy (gameObject, 10f);
	}

	public bool IsDying()
    {
		return this.dying;
	}

	public void ActivationIsKinematic()
    {
		GetComponent<Rigidbody> ().isKinematic = true;
	}
}
