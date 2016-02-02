using UnityEngine;
using System.Collections;

public class ClinkOnBounce : MonoBehaviour {
	public AudioClip[] clinks;

	AudioSource clinkSource;
	// Use this for initialization
	void Start () {
		AudioSource existingAudioSource = GetComponent<AudioSource>();
		clinkSource = gameObject.AddComponent<AudioSource>();
		clinkSource.outputAudioMixerGroup = existingAudioSource.outputAudioMixerGroup;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "ground"){
			clinkSource.PlayOneShot(clinks[Random.Range(0, clinks.Length)]);
		}
	}
}
