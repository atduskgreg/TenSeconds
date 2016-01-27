using UnityEngine;
using System.Collections;

public class SpawnAnimation : MonoBehaviour {
	public float time = 0.5f;
	public float startScale = 0.0f;

	public bool growOnStart = true;

	private Vector2 endScale;

	void Start () {
		time += Random.Range(-0.2f, 0.2f);
		endScale = new Vector2(transform.localScale.x, transform.localScale.y);
		transform.localScale = new Vector2(startScale, startScale);
		if(growOnStart){
			StartGrow ();
		}
	}
	
	void Update () {
	
	}

	public void StartGrow(){
		print ("StartGrow()");
		StartCoroutine(GrowTo(time));
	}

	IEnumerator GrowTo(float time){
		Vector2 oScale = transform.localScale;

		for (float t = 0.0f; t < time; t += Time.deltaTime ){


			float x = (float)Easing.ElasticEaseInOut(t, oScale.x, endScale.x - oScale.x, time);
			float y = (float)Easing.ElasticEaseInOut(t, oScale.y, endScale.y - oScale.y, time);

			transform.localScale = new Vector2(x, y);
			yield return null;
		}
	}
}
