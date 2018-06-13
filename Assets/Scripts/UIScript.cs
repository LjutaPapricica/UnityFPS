using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public Text txtAmmos, txtMags, txtLife;
	public Image imgLife;

	// Use this for initialization
	void Start () {
		
	}
	
	public void UpdateTxtAmmunition(int ammos, int maxAmmos, int mags){
		txtAmmos.text = "Ammos : " + ammos + "/" + maxAmmos;
		txtMags.text = "Mags : " + mags;
	}

	public void UpdateLife(int hp){
		hp = Mathf.Clamp (hp, 0, 100);
		imgLife.fillAmount = ((float) hp) / 100;
		txtLife.text = "HP " + hp + "%";
	}

}