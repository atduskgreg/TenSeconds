using UnityEngine;
using System.Collections;

public class DimColor : MonoBehaviour {
	public float dimTime = 1.0f;

	public void StartDim(){
		StartCoroutine(DoDim(dimTime));
	}

	IEnumerator DoDim(float time){
		for (float t = 0.0f; t < time; t += Time.deltaTime ){
			float grayAmt = 0.0f;
			if(t < time){
				grayAmt = (float)Easing.QuadEaseOut(t, 0, 3, time/2);
			} else {
				grayAmt = (float)Easing.QuadEaseOut(t - time/2, 3, 0, time/2);
			}

			gameObject.GetComponent<Renderer>().material.SetFloat("_EffectAmount", grayAmt);

			yield return null;
		}
		gameObject.GetComponent<Renderer>().material.SetFloat("_EffectAmount", 0);

	}
}
