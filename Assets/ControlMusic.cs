using UnityEngine;
using System.Collections;

public class ControlMusic : MonoBehaviour {
	public float bpm = 127.0F;
	public int numBeatsPerSegment = 4;

	public AudioClip[] drumLoops;
	public AudioClip[] alarms;

	public AudioSource alarmSource;

	public float drumVolume = 0.7f;

	public bool playOnStart = true;

	int currentDrumLoop = 0;
	int currentAlarm = -1;

	private double nextClipTime = 0.0;
	private bool running = false;

	private AudioSource[] audioSources = new AudioSource[2];
	private int flip = 0;
	float startingAlarmVolume;

	void Start () {
		int i = 0;
		while (i < 2) {
			audioSources[i] = gameObject.AddComponent<AudioSource>();
			audioSources[i].volume = drumVolume;
			i++;
		}

		startingAlarmVolume = alarmSource.volume;
		nextClipTime = AudioSettings.dspTime + 1.1f;

		running = playOnStart;
	}

	public void StopMusic(){
		running = false;
	}

	public void StartMusic(){
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

			if(currentAlarm == -1){
				alarmSource.volume = 0;

			} else{
				alarmSource.volume = startingAlarmVolume;

				alarmSource.clip = alarms[currentAlarm];
				alarmSource.PlayScheduled(nextClipTime);
			}


			nextClipTime += 60.0F / bpm * numBeatsPerSegment;
			flip = 1 - flip;
		}
	}

	public void SetAlarm(int a){
		currentAlarm = a;
	}

	public void incrementAlarm(){
		currentAlarm++;
		if(currentAlarm >= alarms.Length){
			currentAlarm = alarms.Length-1;
		}

	}

	public void decrementAlarm(){
		currentAlarm--;
		if(currentAlarm <= -1){
			currentAlarm = -1;
		}
	}
}
