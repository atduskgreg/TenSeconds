using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class EnforceAudioPrefs : MonoBehaviour {
	public AudioMixer mixer;


	void Start () {
		Enforce();
	}


	public void Enforce(){
		if(PlayerPrefs.GetInt("playMusic") == 1 &&  PlayerPrefs.GetInt("playSFX") == 1){
			mixer.FindSnapshot("MusicAndSFX").TransitionTo(0);
		}
		
		if(PlayerPrefs.GetInt("playMusic") == 1 &&  PlayerPrefs.GetInt("playSFX") == 0){
			mixer.FindSnapshot("MusicOnly").TransitionTo(0);
		}
		
		if(PlayerPrefs.GetInt("playMusic") == 0 &&  PlayerPrefs.GetInt("playSFX") == 1){
			mixer.FindSnapshot("SFXOnly").TransitionTo(0);
			
		}
		
		if(PlayerPrefs.GetInt("playMusic") == 0 &&  PlayerPrefs.GetInt("playSFX") == 0){
			mixer.FindSnapshot("None").TransitionTo(0);
		}
	}
}
