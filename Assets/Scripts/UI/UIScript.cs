using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

	public Text TxtAmmos, TxtMags, TxtLife;
	public Image ImgLife;

	public void UpdateTxtAmmunition(int ammos, int maxAmmos, int mags)
    {

		TxtAmmos.text = "Ammos : " + ammos + "/" + maxAmmos;
		TxtMags.text = "Mags : " + mags;
	}

	public void UpdateLife(int hp)
    {

		hp = Mathf.Clamp (hp, 0, 100);
		ImgLife.fillAmount = ((float) hp) / 100;
		TxtLife.text = "HP " + hp + "%";
	}

}