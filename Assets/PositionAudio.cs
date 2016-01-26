using UnityEngine;
using System.Collections;

public class PositionAudio : MonoBehaviour {
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		float p = Camera.main.WorldToViewportPoint(transform.position).x;
		audioSource.panStereo = p.Remap(0,1, -1, 1);
	}
}
