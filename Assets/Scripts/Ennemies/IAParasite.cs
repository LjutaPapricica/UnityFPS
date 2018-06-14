using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAParasite : MonoBehaviour
{

	public GameObject Target;
	public float DetectionDistance = 10f;
	public float AttackDistance = 2f;
	public float MinSpeed=0.9f, MaxSpeed=1.1f;
	public int Damages = 10;
	public AudioClip SoundAttack;

	private NavMeshAgent agent;
	private Animator animator;

	[SerializeField]
	private float distance;

	// Use this for initialization
	void Start ()
    {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		agent.speed = Random.Range (MinSpeed, MaxSpeed);
		Target = GameObject.Find ("FPSController");
	}
	
	// Update is called once per frame
	void Update ()
    {
		distance = Vector3.Distance (Target.transform.position, transform.position);
		if (distance < DetectionDistance)
        {
			animator.SetBool ("walk", true);
			agent.SetDestination (Target.transform.position);

			if (distance < AttackDistance)
            {
				animator.SetBool ("attack", true);
				agent.SetDestination (transform.position);

			}
            else
            {
				animator.SetBool ("attack", false);
			}
		}
        else
        {
			animator.SetBool ("walk", false);
			agent.SetDestination (transform.position);
		}

	}

	public void damageToPlayerEvent()
    {
		GameObject.Find ("FPSController").GetComponent<HealthScript> ().DamagePlayer (Damages);
		GetComponent<AudioSource> ().PlayOneShot (SoundAttack);
	}
}
