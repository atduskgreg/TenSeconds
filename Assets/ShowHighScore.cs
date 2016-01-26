using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShowHighScore : MonoBehaviour {
	public Text highScoreDisplay;
	public Text lastScoreDisplay;

	public Image newRecordImage;

	void Start () {
		UpdateScores();
	}

	public void UpdateScores(){
		float highscore = Mathf.Round(PlayerPrefs.GetFloat("highscore"));
		float lastscore = Mathf.Round(PlayerPrefs.GetFloat("lastScore"));
		
		highScoreDisplay.text = ((int)highscore).ToString("F2").Replace('.', ':');
		lastScoreDisplay.text = ((int)lastscore).ToString("F2").Replace('.', ':');


//		if(highscore.Equals(lastscore)){
//			newRecordImage.enabled = true;
//		} else {
//			newRecordImage.enabled = false;
//			
//		}
	}
	
	void Update () {
		if(Input.GetKeyDown("r")){

			PlayerPrefs.SetFloat("highscore", 0.0f);
			highScoreDisplay.text = Mathf.Round(PlayerPrefs.GetFloat("highscore")).ToString("F2");

		}
	}
}
