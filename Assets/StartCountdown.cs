using UnityEngine;
using System.Collections;

public class StartCountdown : MonoBehaviour {

	public float timePerStep = 1.0f;
	public AudioClip[] startSounds;


	int totalFrames = 4;

	bool begun = false;


	void Start () {
		JumpToFrame(0);
		if(Application.loadedLevelName == "MainScene"){
			JumpToFrame (3);
			GetComponent<AudioSource>().clip = startSounds[startSounds.Length-1];
			GetComponent<AudioSource>().Play();
			GetComponent<Bounce>().DoBounce ();
		}
	}

	void Update(){
		if(!begun && GameObject.Find("TimerWidget").GetComponent<Bounce>().isComplete()){
			begun = true;
			Begin ();
		}
	}

	public void Begin(){
		StartCoroutine(DoCountdownStep(0));
	}

	void JumpToFrame(int frame){
		GetComponent<Animator>().speed = 0;
		GetComponent<Animator>().Play("Lights321", 0 , (1/(float)totalFrames)*(float)frame);
	}
	
	IEnumerator DoCountdownStep(int currStep){
		// set correct animation frame
		JumpToFrame(currStep);
		// start sound playing
		if(currStep > 0){
			GetComponent<AudioSource>().clip = startSounds[currStep-1];
			GetComponent<AudioSource>().Play();
		}
		// wait 
		yield return new WaitForSeconds(timePerStep);

		print ("currStep : " + currStep + " totalFrames: " + totalFrames);

		if(currStep < totalFrames-1){
			StartCoroutine(DoCountdownStep(currStep+1));
		} else {
			Application.LoadLevel("MainScene");
		}
	}
}
