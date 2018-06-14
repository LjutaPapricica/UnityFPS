using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{

	public AudioClip SoundShoot;
	public AudioClip SoundReload;
	public AudioClip SoundEmpty;
	public GameObject BulletHolePrefab;
	public GameObject SparksPrefab;
	public float FireRate = 1;
    public int Rounds;
    public int MaxRounds;
	public int Magazines;
    public bool IsAuto = true;
    public bool CanFire = false;
	public int WeaponDamages;
	public int MaxMags;

    private Ray ray;
    private RaycastHit hit;
    private float nextFire;
    private GameObject panelUI;


    //For animation script
    public float GetNextFire()
    {
		return this.nextFire;
	}

	// Use this for initialization
	void Start ()
    {
		panelUI = GameObject.Find ("PanelUI");

		Debug.Log (panelUI);

		panelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (Rounds, MaxRounds, Magazines);
	}

	void OnEnable()
    {
		panelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (Rounds, MaxRounds, Magazines);
	}

	void Update ()
    {

		if (Time.time > nextFire)
        {
			CanFire = true;
		}
        else
        {
			CanFire = false;
		}

		if (IsAuto)
        {

			if (Input.GetButton ("Fire1"))
            {
				Fire ();
			}

		}
        else
        {

			if (Input.GetButtonDown ("Fire1"))
            {
				Fire ();
			}


		}



		if (Input.GetButtonDown ("Fire1") && Rounds == 0)
        {
			GetComponent<AudioSource> ().PlayOneShot (SoundEmpty);
		}

		if (Input.GetKeyDown (KeyCode.R) && Magazines > 0 && Rounds < MaxRounds)
        {
			GetComponent<AudioSource> ().PlayOneShot (SoundReload);
			StartCoroutine (Reload ());
		}
	}

	IEnumerator Reload()
    {
		yield return new WaitForSeconds (0.2f);
		Magazines -= 1;
		Rounds = MaxRounds;
		panelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (Rounds, MaxRounds, Magazines);
	}

	void Fire()
    {
		if (CanFire)
        { //Fire rate
			if (Rounds > 0)
            {

				Rounds--;
				panelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (Rounds, MaxRounds, Magazines);
				nextFire = Time.time + FireRate;
				GetComponent<AudioSource> ().PlayOneShot (SoundShoot);

				//Get screen center as raycast target
				Vector2 screenCenterPoint = new Vector2 (Screen.width / 2, Screen.height / 2);
				ray = Camera.main.ScreenPointToRay (screenCenterPoint);
				if (Physics.Raycast (ray, out hit, Camera.main.farClipPlane))
                {
					if (hit.transform.gameObject.tag == "target")
                    {
						Destroy (hit.transform.gameObject);
					}
					if (hit.transform.gameObject.tag == "ennemy")
                    {
						if (!hit.transform.gameObject.GetComponent<DeathScript> ().IsDying ())
                        {
							hit.transform.gameObject.GetComponent<DeathScript> ().Death (WeaponDamages);
						}

					}
					if (hit.transform.gameObject.tag == "decors")
                    {

						//Bullet hole
						GameObject Impact;
						Impact = Instantiate (BulletHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
						Destroy (Impact, 20f);

						//Sparks
						GameObject Sparks = Instantiate(SparksPrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)) as GameObject;
						Destroy (Sparks, 3f);
					}
				}
			}
		}
	}

	public void AddMagazines(int nbMags)
    {
		Magazines = Mathf.Min(nbMags + Magazines, MaxMags);
		panelUI.GetComponent<UIScript> ().UpdateTxtAmmunition (Rounds, MaxRounds, Magazines);
	}
}
