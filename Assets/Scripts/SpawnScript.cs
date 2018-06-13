using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

	public GameObject ObjectToSpawn, Player;
	public float distanceSpawn = 50f;
	public float spawnRate = 2f;
	float nextSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (Player.transform.position, transform.position);
		if (distance < distanceSpawn && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			Instantiate (ObjectToSpawn, transform.position, Quaternion.identity);
		}
		
	}
}
