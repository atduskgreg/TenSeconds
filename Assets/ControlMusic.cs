using UnityEngine;
using System.Collections;

public class ControlMusic : MonoBehaviour {
	public float bpm = 127.0F;
	public int numBeatsPerSegment = 4;

	public AudioClip[] drumLoops;
	public AudioClip[] alarms;

	public AudioSource drumSource;
	public AudioSource alarmSource;

	int currentDrumLoop = 0;
	int currentAlarm = 0;

	private double nextClipTime = 0.0;
	private bool running = false;

	private AudioSource[] audioSources = new AudioSource[2];
	private int flip = 0;

	void Start () {
		int i = 0;
		while (i < 2) {
			audioSources[i] = gameObject.AddComponent<AudioSource>();
			i++;
		}

		nextClipTime = AudioSettings.dspTime + 2.0f;
		running = true;
	}
	
	void Update () {

		if(Input.GetKeyDown("=")){
			incrementAlarm();
		}

		if(Input.GetKeyDown("-")){
			decrementAlarm();
		}

		if(!running){
			return;
		}


		double time = AudioSettings.dspTime;
		if (time + 1.0F > nextClipTime) {
			currentDrumLoop++;
			if(currentDrumLoop > drumLoops.Length-1){
				currentDrumLoop = 0;
			}
		
			audioSources[flip].clip = drumLoops[currentDrumLoop];
			audioSources[flip].PlayScheduled(nextClipTime);
			alarmSource.clip = alarms[currentAlarm];
			alarmSource.PlayScheduled(nextClipTime);
			nextClipTime += 60.0F / bpm * numBeatsPerSegment;
			flip = 1 - flip;
		}


//			alarmSource.clip = alarms[currentAlarm];
//			alarmSource.Play ();
//			


//		if(!alarmSource.isPlaying){
//			alarmSource.clip = alarms[currentAlarm];
//			alarmSource.Play ();
//		}
	}

	void incrementAlarm(){
		currentAlarm++;
		if(currentAlarm >= alarms.Length){
			currentAlarm = alarms.Length-1;
		}

	}

	void decrementAlarm(){
		currentAlarm--;
		if(currentAlarm <= 0){
			currentAlarm = 0;
		}

	}
}
