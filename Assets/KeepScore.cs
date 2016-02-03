using UnityEngine;
using System.Collections;

public class KeepScore : MonoBehaviour {
	public bool timeUp = false;
	public bool keepTime = true;

	SpriteRenderer rd;
	public float startingTotal = 10.0f;
	public float totalTime;

	public AudioClip[] countdown;

	Vector3 startingScale;
	float startTime;	
	private float score = 0.0f;
	private GameObject scorePanel;
	private GameObject timerWidget;

	float prevTime = 10.0f;

	void Start () {
		rd = gameObject.GetComponent<SpriteRenderer>();
		rd.color = Color.green;
		startingScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

		scorePanel = GameObject.Find ("ScorePanel");
		timerWidget = GameObject.Find ("TimerWidget");
//		gameOverNotice.SetActive(false);
//		rd.sortingOrder = 1;
		totalTime = startingTotal;
		ResetTime ();
	}
	
	void Update () {
		if(GameOn()){
			timeUp = false;

			score = Time.timeSinceLevelLoad - startTime;

			float t = (RemainingTime())/startingTotal;

			if(GetComponent<AudioSource>() && !GetComponent<AudioSource>().isPlaying){
				if(prevTime > 3.0 && RemainingTime() <= 3.0){
					GetComponent<AudioSource>().clip = countdown[2];
					GetComponent<AudioSource>().Play();
				}

				if(prevTime > 2.0 && RemainingTime() <= 2.0){
					GetComponent<AudioSource>().clip = countdown[1];
					GetComponent<AudioSource>().Play();
				}

				if(prevTime > 1.0 && RemainingTime() <= 1.0){
					print ("should fire");
					GetComponent<AudioSource>().clip = countdown[0];
					GetComponent<AudioSource>().Play();
				}
			}

			prevTime = RemainingTime();

			float g = t;

			float r = 1-t;
			rd.color = new Color(r,g,0);
			transform.localScale = new Vector3(t * startingScale.x, startingScale.y, startingScale.z );
		} else {
			timeUp = true;
			EndGame();

			if(timerWidget.GetComponent<Bounce>().isComplete()){
				Application.LoadLevel("StartScreen");
			}
		}
	}
	
	public bool GameOn(){
		return RemainingTime() > 0;
	}

	public void ResetTime(){
		startTime = Time.timeSinceLevelLoad;
	}

	public float RemainingTime(){
		if(keepTime){
			return totalTime + startTime - Time.timeSinceLevelLoad;
		} else {
			return totalTime;
		}
	}

	public float Score(){
		return score;
	}


	void StoreHighscore() {
		float oldHighscore = PlayerPrefs.GetFloat("highscore", 0.0f); 
		if(Score() > oldHighscore){
			PlayerPrefs.SetFloat("highscore", Score());
			PlayerPrefs.SetInt("newHighScore", 1);
		}

		PlayerPrefs.SetFloat("lastScore", Score());
		PlayerPrefs.Save ();

	}

	void EndGame(){
		GameObject.Find ("player").GetComponent<Rigidbody2D>().isKinematic = true;

//		if(Application.loadedLevelName == "Tutorial1"){
//		}
		StoreHighscore();
		GameObject.Find ("ScoreCanvas").GetComponent<ShowHighScore>().UpdateScores();

	
		timerWidget.GetComponent<Bounce>().DoBounce();

	
//		rd.color = Color.black;


	}
}
