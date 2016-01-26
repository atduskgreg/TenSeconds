using UnityEngine;
using System.Collections;

public class ManageTutorial : MonoBehaviour {
	public int tutorialStep;
	public bool isLastTutorialStep = false;
	
	public GameObject[] stepImages;
	public TutorialClickTarget[] clickTargets;
	int currentStep = -1;
	int currentClickTarget = -1;
	
	public void FinishTutorialStep(){
		print ("FinishTutorialStep()");
		if(!isLastTutorialStep){
			int nextTutorialStep = tutorialStep + 1;
			Application.LoadLevel("Tutorial"+nextTutorialStep);
		}
	}

	void Start () {
		ShowNextStep();
		ActivateNextTarget();
	}

	void ShowNextStep(){
		currentStep++;
		for(int i = 0; i < stepImages.Length; i++){
			if(i == currentStep){
				stepImages[i].SetActive(true);

			} else{
				stepImages[i].SetActive(false);
			
			}
		}
	}

	void ActivateNextTarget(){
		currentClickTarget++;
		for(int i = 0; i < clickTargets.Length; i++){
			if(i == currentClickTarget){
				clickTargets[i].GetComponent<Collider2D>().enabled = true;
				clickTargets[i].BeginTime();
			} else {
				clickTargets[i].GetComponent<Collider2D>().enabled = false;
			}
		}
	}

	public void Next(){
		ShowNextStep();
		ActivateNextTarget();
		print ("currentClickTarget: " + currentClickTarget + " " + Time.timeSinceLevelLoad);

	}

	void Update () {

	}
}
