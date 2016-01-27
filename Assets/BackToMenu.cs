using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	void Start () {
	
	}

	// TODO: add animating down the timerwidget
	public void GoBackToMenu(){
		Application.LoadLevel("StartScreen");
	}

	void Update () {
	
	}
}
