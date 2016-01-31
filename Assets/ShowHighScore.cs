using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShowHighScore : MonoBehaviour {
	public Text highScoreDisplay;
	public Text lastScoreDisplay;

	public GameObject highScoreIndicator;
	public AudioClip[] celebrationSounds;

	void Start () {
		UpdateScores();
	}

	public void UpdateScores(){
		float highscore = Mathf.Round(PlayerPrefs.GetFloat("highscore"));
		float lastscore = Mathf.Round(PlayerPrefs.GetFloat("lastScore"));
		
		highScoreDisplay.text = ((int)highscore).ToString("F2").Replace('.', ':');
		lastScoreDisplay.text = ((int)lastscore).ToString("F2").Replace('.', ':');


				
		if(Application.loadedLevelName == "StartScreen" && PlayerPrefs.GetInt("newHighScore") == 1){
			highScoreIndicator.GetComponent<Animator>().speed = 1;
			highScoreIndicator.GetComponent<Animator>().Play("IndicatorLight", 0 , 0);
			GetComponent<AudioSource>().clip = celebrationSounds[Random.Range (0,celebrationSounds.Length)];
			GetComponent<AudioSource>().Play();
			PlayerPrefs.SetInt("newHighScore", 0);
		} else {

			highScoreIndicator.GetComponent<Animator>().speed = 0;
			highScoreIndicator.GetComponent<Animator>().Play("IndicatorLight", 0 , 0);
			

		}
	}
	
	void Update () {
		if(Input.GetKeyDown("r")){

			PlayerPrefs.SetFloat("highscore", 0.0f);
			highScoreDisplay.text = Mathf.Round(PlayerPrefs.GetFloat("highscore")).ToString("F2").Replace('.', ':');

		}
	}
}
