using UnityEngine;
using System.Collections;

public class CleanupShard : MonoBehaviour {
	public float minTime = 1.0f;
	public float maxTime = 6.0f;
	
	void Start () {
		float waitTime = Random.Range(minTime, maxTime);
		StartCoroutine(WaitAndDie(waitTime));
		StartCoroutine(FadeTo(0.0f, waitTime));
	}

	IEnumerator WaitAndDie(float time){
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}

	IEnumerator FadeTo(float aValue, float aTime){
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
	}
	
	void Update () {
	}
}
