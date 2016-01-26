using UnityEngine;
using System.Collections;

public class Cleanup : MonoBehaviour {
	public float waitTime;

	void Start () {
		StartCoroutine(WaitAndDie(waitTime));
	}

	IEnumerator WaitAndDie(float time){
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}
	
	void Update () {
	
	}
}
