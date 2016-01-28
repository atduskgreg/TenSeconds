using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {
	public float riseTime = 1.5f;
	public Vector2 finalPos;
	public bool easeIn = true;

	public AudioClip[] movementSounds;


	bool complete = false;

	void Start () {

	}

	public void DoBounce(){
		if(movementSounds.Length > 0){
			GetComponent<AudioSource>().clip = movementSounds[Random.Range (0, movementSounds.Length)];
			GetComponent<AudioSource>().Play ();
		}
//		complete = false;

		StartCoroutine(BounceTo(finalPos, riseTime));
	}

	public bool isComplete(){
		return complete;
	}

	void Update () {
		
	}

	public IEnumerator BounceTo(Vector2 targetPos, float time){
		Vector2 startPos = transform.position;
		for (float t = 0.0f; t < time; t += Time.deltaTime ){
			float y;
			if(easeIn){
				y = (float)Easing.ElasticEaseInOut(t, startPos.y, targetPos.y - startPos.y, time);
			} else {
				y = (float)Easing.ElasticEaseOut(t, startPos.y, targetPos.y - startPos.y, time);
			}
			 
			transform.position = new Vector2(transform.position.x, y);
			yield return null;
		}
		complete = true;
	}



}
