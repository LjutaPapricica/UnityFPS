using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAParasite : MonoBehaviour {

	public GameObject target;
	public float detectionDistance = 10f;
	public float attackDistance = 2f;
	public float minSpeed=0.9f, maxSpeed=1.1f;
	public int damages = 10;
	public AudioClip soundAttack;

	private NavMeshAgent agent;
	private Animator animator;
	[SerializeField]
	private float distance;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		agent.speed = Random.Range (minSpeed, maxSpeed);
		target = GameObject.Find ("FPSController");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (target.transform.position, transform.position);
		if (distance < detectionDistance) {
			animator.SetBool ("walk", true);
			agent.SetDestination (target.transform.position);

			if (distance < attackDistance) {
				animator.SetBool ("attack", true);
				agent.SetDestination (transform.position);

			} else {
				animator.SetBool ("attack", false);
			}
		} else {
			animator.SetBool ("walk", false);
			agent.SetDestination (transform.position);
		}

	}

	public void damageToPlayerEvent(){
		GameObject.Find ("FPSController").GetComponent<HealthScript> ().damagePlayer (damages);
		GetComponent<AudioSource> ().PlayOneShot (soundAttack);
	}
}
