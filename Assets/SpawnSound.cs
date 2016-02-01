using UnityEngine;
using System.Collections;

public class SpawnSound : MonoBehaviour {
	public AudioSource source;
	public AudioClip[] clips;
	
	public void Play(){
		int i = Random.Range (0,clips.Length);
		source.clip = clips[i];
		source.Play();
	}

}
