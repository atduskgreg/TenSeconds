using UnityEngine;
using System.Collections;

public class ManageTutorial : MonoBehaviour {

	public TutorialClickTarget[] clickTargets;
	int currentClickTarget = -1;

	void Start () {
		ActivateNextTarget();
	}
	
	void ActivateNextTarget(){
		currentClickTarget++;
		for(int i = 0; i < clickTargets.Length; i++){
			if(i == currentClickTarget){

				clickTargets[i].BeginTime();
				clickTargets[i].gameObject.SetActive(true);

			} else {
				clickTargets[i].gameObject.SetActive(false);

			}
		}
	}

	public void Next(){
		ActivateNextTarget();
	}

	void Update () {

	}
}
