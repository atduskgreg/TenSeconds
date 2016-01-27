using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {
	bool exitRequested = false;

	GameObject timerWidget;

	void Start () {
		timerWidget = GameObject.Find("TimerWidget");
	}

	public void GoBackToMenu(){
		exitRequested = true;
		GameObject.Find ("player").GetComponent<Rigidbody2D>().isKinematic = true;
		StartCoroutine(timerWidget.GetComponent<Bounce>().BounceTo(new Vector2(0, -6.6f), 0.5f));
	}

	void Update () {
		if(exitRequested && timerWidget.GetComponent<Bounce>().isComplete()){
			Application.LoadLevel("StartScreen");

		}
	}
}
