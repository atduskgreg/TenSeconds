using UnityEngine;
using System.Collections;

public class SpawnSound : MonoBehaviour {
	public AudioSource source;
	public AudioClip[] clips;

	void Start(){
		int i = Random.Range (0,clips.Length);
		print ("playng spawn sound " + i) ;
		source.clip = clips[i];
		source.Play();
	}

}
