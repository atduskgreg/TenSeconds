using UnityEngine;
using System.Collections;

public class TutorialClickTarget : MonoBehaviour {

	public bool isCollectionTarget = false;
	public bool isUseBonusTarget = false;
	public bool isStartClockTarget = false;

	public bool isTimed = false;
	public float liveTime = 3; // seconds 
	
	public GameObject[] ObjectsToAdd;

	public GetHitTutorial collectionTarget;


	float startTime;
	bool timeStarted = false;
	bool alreadyCollected = false;
	int numStartingBonuses;

	ManageTutorial manager;
	BonusLifecycle bl;
	KeepScore score;

	void Start () {
		manager = (ManageTutorial)GameObject.Find("TutorialManager").GetComponent(typeof(ManageTutorial));
		bl = (BonusLifecycle)GameObject.Find("ObstacleManager").GetComponent(typeof(BonusLifecycle));
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));

		if(isCollectionTarget || isTimed){
			GetComponent<Collider2D>().enabled = false;
		}
		if(ObjectsToAdd.Length > 0){
			for(int i = 0; i< ObjectsToAdd.Length; i++){
				print (ObjectsToAdd[i]);
				ObjectsToAdd[i].SetActive(false);
			}
		}
	}

	public void BeginTime(){
		if(isTimed){
			startTime = Time.timeSinceLevelLoad;
			timeStarted = true;
		}
		if(isUseBonusTarget){
			numStartingBonuses = bl.GetNumWipeouts();
		}
		if(isStartClockTarget){
			score.ResetTime();
			score.keepTime = true;
		}

		if(ObjectsToAdd.Length > 0){
			for(int i = 0; i< ObjectsToAdd.Length; i++){
				ObjectsToAdd[i].SetActive(true);
				ObjectsToAdd[i].GetComponent<SpawnAnimation>().StartGrow();

				if(ObjectsToAdd[i].GetComponent<ChasePlayerTutorial>()){
					ObjectsToAdd[i].GetComponent<ChasePlayerTutorial>().Begin();
					bl.AddTrap(ObjectsToAdd[i]);
				}

			}
		}

		if(isStartClockTarget){
			bl.numWipeouts = 2;
			GameObject.Find("WipeoutDisplay").GetComponent<UpdateWipeoutDisplay>().Refresh();
			bl.PlaceBonus();
		}
	}
	
	void Update () {
		if(isTimed && timeStarted && (Time.timeSinceLevelLoad - startTime >= liveTime)){
			timeStarted = false;
			manager.Next();
		}
	
		if(isCollectionTarget && collectionTarget.collected && !alreadyCollected){
			manager.Next();
			alreadyCollected = true;
		}

		if(isUseBonusTarget && bl.GetNumWipeouts() < numStartingBonuses && !alreadyCollected){
			manager.Next();
			alreadyCollected = true;
		}
	}

	void OnMouseDown(){
		if(!isCollectionTarget && !isTimed && !isUseBonusTarget){
			manager.Next();
		}
	}
}
