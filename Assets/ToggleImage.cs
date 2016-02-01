using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour {

	public AudioClip toggleSound;
	public string settingName;

	AudioSource audioSource;

	void Start () {
		audioSource = GameObject.Find ("ScorePanel").GetComponent<AudioSource>();
		GetComponent<Toggle>().isOn = (PlayerPrefs.GetInt(settingName) == 1);
	}
	
	void Update () {	
	}

	public void OnValueChanged(bool toggleOn){
		audioSource.PlayOneShot(toggleSound);
		if(toggleOn){
			PlayerPrefs.SetInt(settingName, 1);
		} else {
			PlayerPrefs.SetInt(settingName, 0);

		}
	}
}
