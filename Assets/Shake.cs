using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shake : MonoBehaviour {
	public float shakeAmount  = 0.1f;
	public float shakeDecay = 10.0f;
	public GameObject[] guiElements;

	public Vector3[] guiElementStarts;
	public Canvas canvas;

	float shake = 0.0f;
	Vector3 prevCameraPos;

	void Start () {
		guiElementStarts = new Vector3[guiElements.Length];
		for(int i = 0; i < guiElements.Length; i++){
			guiElementStarts[i] = new Vector3(guiElements[i].transform.position.x, guiElements[i].transform.position.y, guiElements[i].transform.position.z);

		}

	}
	
	void Update () {
		if(shake > 0){
			Vector2 r = Random.insideUnitCircle * shakeAmount;

			gameObject.transform.localPosition =  new Vector3(r.x, r.y, -10);
//			canvas.transform.localPosition =  new Vector3(r.x, r.y, 0);

//			for(int i = 0; i < guiElements.Length; i++){
//				guiElements[i].transform.position =  new Vector3(guiElementStarts[i].x + r.x, guiElementStarts[i].y + r.y, 3);
//			}

			shake -= Time.deltaTime * shakeDecay;
		} else {
			shake = 0.0f;
			gameObject.transform.position = new Vector3(0,0,-10);
//			canvas.transform.localPosition =  new Vector3(0,0,0);

//			for(int i = 0; i < guiElements.Length; i++){
//				guiElements[i].transform.position =  guiElementStarts[i];
//			}
		}


	}

	public void ApplyShake(float amt){
		shake = amt;
	}
}
