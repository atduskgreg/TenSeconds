﻿using UnityEngine;
using System.Collections;

public class PlayGeigerSounds : MonoBehaviour {

	public AudioClip[] geigerSounds;
	public AudioSource audioSource;

	KeepScore score;

	void Start () {
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));

		audioSource.volume = 1;
		audioSource.clip = geigerSounds[Random.Range(0, geigerSounds.Length)];
		audioSource.Play();


	}
	
	void Update () {
		if(!score.GameOn()){
			audioSource.volume = 0;
		}

		if (!audioSource.isPlaying){
			audioSource.clip = geigerSounds[Random.Range(0, geigerSounds.Length)];
			audioSource.Play();
		}


	}
}
