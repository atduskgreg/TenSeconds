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
		print (Time.timeSinceLevelLoad);
		manager = (ManageTutorial)GameObject.Find("TutorialManager").GetComponent(typeof(ManageTutorial));
		bl = (BonusLifecycle)GameObject.Find("ObstacleManager").GetComponent(typeof(BonusLifecycle));
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));

		if(isCollectionTarget || isTimed){
			GetComponent<Collider2D>().enabled = false;
		}
		if(ObjectsToAdd.Length > 0){
			print ("ObjectToAdd");
			for(int i = 0; i< ObjectsToAdd.Length; i++){
				ObjectsToAdd[i].SetActive(false);
			}
		}
	}

	public void BeginTime(){
		if(isTimed){
			startTime = Time.timeSinceLevelLoad;
			print(startTime);
			timeStarted = true;
		}
		if(isUseBonusTarget){
			numStartingBonuses = bl.GetNumWipeouts();
			print ("numStartingBonuses: " + numStartingBonuses);
		}
		if(isStartClockTarget){
			// here: tell score to ResetTime()
			// set keeptime to true
		}

		if(ObjectsToAdd.Length > 0){
			for(int i = 0; i< ObjectsToAdd.Length; i++){
				ObjectsToAdd[i].SetActive(true);
				if(ObjectsToAdd[i].GetComponent<ChasePlayerTutorial>()){
					ObjectsToAdd[i].GetComponent<ChasePlayerTutorial>().Begin();
					bl.AddTrap(ObjectsToAdd[i]);
				}

			}

		}
	}
	
	void Update () {
		if(isTimed && timeStarted && (Time.timeSinceLevelLoad - startTime >= liveTime)){
			print ("isTimed");
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
		print ("OnMouseDown");
		if(!isCollectionTarget && !isTimed && !isUseBonusTarget){
			manager.Next();
		}
	}
}
