using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {

	public void playGame(){
		SceneManager.LoadScene ("level1");
	}

	public void quitGame(){
		Application.Quit ();
	}
}
