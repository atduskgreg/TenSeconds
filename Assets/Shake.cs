using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shake : MonoBehaviour {
	public float shakeAmount  = 0.1f;
	public float shakeDecay = 10.0f;
	
	float shake = 0.0f;
	Vector3 prevCameraPos;

	void Start () {

	}
	
	void Update () {
		if(shake > 0){
			Vector2 r = Random.insideUnitCircle * shakeAmount;

			gameObject.transform.localPosition =  new Vector3(r.x, r.y, -10);

			shake -= Time.deltaTime * shakeDecay;
		} else {
			shake = 0.0f;
			gameObject.transform.position = new Vector3(0,0,-10);

		}


	}

	public void ApplyShake(float amt){
		shake = amt;
	}
}
