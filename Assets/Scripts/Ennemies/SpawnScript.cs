using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public GameObject ObjectToSpawn;
    public GameObject Player;
	public float DistanceSpawn = 50f;
	public float SpawnRate = 2f;
	private float nextSpawn = 0;
	
	// Update is called once per frame
	void Update ()
    {
		float distance = Vector3.Distance (Player.transform.position, transform.position);

		if (distance < DistanceSpawn && Time.time > nextSpawn)
        {
			nextSpawn = Time.time + SpawnRate;
			Instantiate (ObjectToSpawn, transform.position, Quaternion.identity);
		}
		
	}
}
