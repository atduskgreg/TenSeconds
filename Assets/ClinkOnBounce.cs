using UnityEngine;
using System.Collections;

public class ClinkOnBounce : MonoBehaviour {
	public AudioClip[] clinks;

	AudioSource clinkSource;
	// Use this for initialization
	void Start () {
		clinkSource = gameObject.AddComponent<AudioSource>();
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
