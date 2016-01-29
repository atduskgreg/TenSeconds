using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusLifecycle : MonoBehaviour {
	public float timeBonus = 3;
	public float timePenalty = 1;

	public Transform bonus;
	public Transform scoreSplash;
	public Transform wipeoutBonus;

	public GameObject progressBar;
	public Transform trap;

	public float timeToMaxTrapChance = 10.0f;
	public int numWipeouts = 2;
	public float chanceOfWipeoutBonus = 0.15f;

	public float enemySpeedIncreaseInterval = 60.0f;

	public int numStartingBonuses = 3;
	public float timeToMinBonuses = 60.0f;

	public AudioClip[] bonusCollectSounds;
	public AudioClip[] superWipeoutSounds;
	public AudioClip[] enemyExplodeSounds;
	public AudioClip[] wipeoutCollectSounds;

	public int numTrapsForSuperSound = 5;
	public float spawningEdgeBuffer = 40.0f;
	public int bottomY = 25;

	public AudioSource secondAudioSource;


//	int numWipeouts = 2;
	bool prevTimeUp = false;

	public Text scoreText;
	public float lastBonusTime;
	public Animator bonusWipeout;
	
	ArrayList currentTraps;
	ArrayList currentBonuses;
	KeepScore score;
	UpdateWipeoutDisplay wipeoutDisplay;



	void Start () {
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));
		wipeoutDisplay = (UpdateWipeoutDisplay)GameObject.Find("WipeoutDisplay").GetComponent(typeof(UpdateWipeoutDisplay));

//		numWipeouts = startingWipeouts;

		currentTraps = new ArrayList();
		currentBonuses = new ArrayList();
		for(int i = 0; i < numStartingBonuses; i++){
			PlaceBonus();
		}
	}
	
	void Update () {
		if(!score.timeUp){

			scoreText.text = score.RemainingTime().ToString("F2").Replace('.', ':');
		} else {
			if(score.timeUp && !prevTimeUp){
				scoreText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString ("F2").Replace('.', ':');
			}
		}


		prevTimeUp = score.timeUp;
		if(Input.GetKeyDown(KeyCode.Space) && !score.timeUp){
			if(numWipeouts > 0 && currentTraps.Count > 0){
				ApplyWipeout();
				AudioSource audioSource = wipeoutDisplay.GetComponent<AudioSource>();
				audioSource.Play();

				numWipeouts--;
				wipeoutDisplay.Refresh();
			}
		}
	}
	public void CollectWipeoutBonus(GameObject collectedBonus){
		AudioSource audioSource = collectedBonus.GetComponent<AudioSource>();
		audioSource.clip = wipeoutCollectSounds[Random.Range (0,wipeoutCollectSounds.Length)];
		audioSource.Play();
		
		// since destroy has to wait for audio clip to finish
		// hide and disable collider in the meantime
//		collectedBonus.GetComponent<Renderer>().enabled = false;
		collectedBonus.GetComponent<Collider2D>().enabled = false;

		collectedBonus.GetComponent<FallToLocation>().Begin();

		
		//Destroy (collectedBonus, audioSource.clip.length);
		numWipeouts++;
		wipeoutDisplay.Refresh();
	}

	public void CollectBonusTutorial(GameObject collectedBonus){
		progressBar.GetComponent<KeepScore>().totalTime += timeBonus;

		AudioSource audioSource = collectedBonus.GetComponent<AudioSource>();
		audioSource.clip = bonusCollectSounds[Random.Range(0, bonusCollectSounds.Length)];
		audioSource.Play();

		Transform sc = (Transform) Instantiate(scoreSplash, collectedBonus.transform.position, Quaternion.identity);
		sc.gameObject.GetComponent<SelectSprite>().BeBonus();
		
		// since destroy has to wait for audio clip to finish
		// hide and disable collider in the meantime
		collectedBonus.GetComponent<Renderer>().enabled = false;
		collectedBonus.GetComponent<Collider2D>().enabled = false;

		Destroy (collectedBonus, audioSource.clip.length);

	}

	public void CollectBonus(GameObject collectedBonus){

		progressBar.GetComponent<KeepScore>().totalTime += timeBonus;

		AudioSource audioSource = collectedBonus.GetComponent<AudioSource>();
		audioSource.clip = bonusCollectSounds[Random.Range(0, bonusCollectSounds.Length)];
		audioSource.Play();


		Transform sc = (Transform) Instantiate(scoreSplash, collectedBonus.transform.position, Quaternion.identity);
		sc.gameObject.GetComponent<SelectSprite>().BeBonus();

		// since destroy has to wait for audio clip to finish
		// hide and disable collider in the meantime
//		collectedBonus.GetComponent<Renderer>().enabled = false;
//		collectedBonus.GetComponent<Collider2D>().enabled = false;
//		collectedBonus.GetComponent<Shatter>().StartShatter();


		currentBonuses.Remove(collectedBonus);

		Destroy (collectedBonus, audioSource.clip.length);


		if(currentBonuses.Count == 0){


			int numBonusesToSpwan = (int)Mathf.Round (Mathf.Clamp((timeToMinBonuses - Time.timeSinceLevelLoad).Remap(0, timeToMinBonuses, 1, numStartingBonuses), 1, numStartingBonuses));

			for(int i = 0; i < numBonusesToSpwan; i++){
				PlaceBonus();
			}
		}

		if(Random.Range(0, 1.0f) < chanceOfWipeoutBonus){
			PlaceWipeoutBonus();
		}


		float chanceOfTrap = Mathf.Clamp(Time.timeSinceLevelLoad.Remap(0, timeToMaxTrapChance, 0, 1), 0, 1);
		float r = Random.Range(0, 1.0f);
		if(r < chanceOfTrap){
			PlaceTrap();
		}

	}

	public int GetNumWipeouts(){
		return numWipeouts;
	}

	public void ApplyWipeout(){

		bonusWipeout.SetTrigger(Animator.StringToHash("Go"));
		AudioSource audioSource = ((GameObject)currentTraps[0]).GetComponent<AudioSource>();
		audioSource.Play();

			int numTrapsDestroyed = currentTraps.Count;

		if(numTrapsDestroyed >= numTrapsForSuperSound){
			secondAudioSource.clip = superWipeoutSounds[Random.Range(0, superWipeoutSounds.Length)];
			secondAudioSource.Play ();
		}

			for (int i = currentTraps.Count - 1; i >= 0; i--)
			{
				GameObject trap = (GameObject)currentTraps[i];
				trap.GetComponent<Renderer>().enabled = false;
				trap.GetComponent<Collider2D>().enabled = false;
				foreach(Transform child in trap.transform){
					Destroy (child.gameObject);
				}


				// play kill bonus animation
				Transform sc = (Transform) Instantiate(scoreSplash, trap.transform.position, Quaternion.identity);
				sc.gameObject.GetComponent<SelectSprite>().BeKillBonus();
				progressBar.GetComponent<KeepScore>().totalTime += 1;

				Destroy (trap, audioSource.clip.length);
				currentTraps.RemoveAt(i);
			}
	
			Camera.main.GetComponent<Shake>().ApplyShake(1.0f * numTrapsDestroyed);
	}

	public void ApplyPenalty(GameObject trapTriggered){

		progressBar.GetComponent<KeepScore>().totalTime -= timePenalty;
		AudioSource audioSource = trapTriggered.GetComponent<AudioSource>();
		audioSource.clip = enemyExplodeSounds[Random.Range(0, enemyExplodeSounds.Length)];
		audioSource.Play();
		

		// need to make a penalty splash
		Transform sc = (Transform) Instantiate(scoreSplash, trapTriggered.transform.position, Quaternion.identity);
		sc.gameObject.GetComponent<SelectSprite>().BePenalty();

		// since destroy has to wait for audio clip to finish
		// hide and disable collider in the meantime
		trapTriggered.GetComponent<Renderer>().enabled = false;
		trapTriggered.GetComponent<Collider2D>().enabled = false;

		currentTraps.Remove (trapTriggered);
		Destroy (trapTriggered, audioSource.clip.length);

	}

	Vector3 RandomOnScreenPoint(){

		float x = Random.Range(0, Camera.main.pixelWidth - spawningEdgeBuffer);
		float y = Random.Range(bottomY, Camera.main.pixelHeight - spawningEdgeBuffer);

		return Camera.main.ScreenToWorldPoint(new Vector3(x,y, 0));
	}

	void PlaceTrap(){
		lastBonusTime = Time.time;

		Transform bt = (Transform)Instantiate(trap, RandomOnScreenPoint(), Quaternion.identity);
		bt.position = new Vector3(bt.position.x, bt.position.y, 0);

		int numIntervals =  (int)Mathf.Floor(score.Score () / enemySpeedIncreaseInterval);
		bt.gameObject.GetComponent<ChasePlayer>().SetSpeedLevel(numIntervals);

		currentTraps.Add (bt.gameObject);
	}

	// this is here for the tutorial
	public void AddTrap(GameObject trap){
//		int numIntervals =  (int)Mathf.Floor(score.Score () / enemySpeedIncreaseInterval);
//		trap.GetComponent<ChasePlayer>().SetSpeedLevel(numIntervals);
		currentTraps.Add(trap);
	}

	void PlaceWipeoutBonus(){


		Transform bt = (Transform)Instantiate(wipeoutBonus, RandomOnScreenPoint(), Quaternion.identity);
		bt.position = new Vector3(bt.position.x, bt.position.y, 0);
	}

	public void PlaceBonus(){
		lastBonusTime = Time.time;

		Transform bt = (Transform)Instantiate(bonus, RandomOnScreenPoint(), Quaternion.identity);
		bt.position = new Vector3(bt.position.x, bt.position.y, 0);

		currentBonuses.Add(bt.gameObject);

	}
}
