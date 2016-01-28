using UnityEngine;
using System.Collections;

public class FallToLocation : MonoBehaviour {
	public float ttl = 0.5f;
	public float speed = 0.1f;

	public string fallTargetName;
	public float startingScale;
	public float endingScale;

	GameObject fallTarget;

	private Vector3 targetPosition;
	
	void Start () {

	}

	public void Begin(){
		fallTarget = GameObject.Find(fallTargetName);
//		startTime = Time.time;
		transform.localScale = new Vector2(startingScale, startingScale);
		StartCoroutine(Grow(new Vector2(endingScale,endingScale), ttl));
		StartCoroutine(Fall(fallTarget.transform.position, ttl));
		StartCoroutine(WaitAndDie(ttl));

	}
	
	void Update () {
//		if(Time.time - startTime > ttl){
//			;
//		}
	}

	IEnumerator WaitAndDie(float time){
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
		
		Destroy (gameObject.transform.parent.gameObject);

	}

	IEnumerator Fall(Vector2 target, float aTime){
		Vector2 initialPosition = transform.position;
		for (float t = 0.0f; t < aTime; t += Time.deltaTime){
			float x = (float)Easing.CubicEaseIn(t, initialPosition.x, target.x - initialPosition.x, aTime);
			float y = (float)Easing.CubicEaseIn(t, initialPosition.y, target.y - initialPosition.y, aTime);

			transform.position = new Vector2(x,y);
			yield return null;
		}
	}


	IEnumerator Grow(Vector2 aScale, float aTime){
		Vector3 initialScale = transform.localScale;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime){
			Vector2 newScale = new Vector2(Mathf.Lerp(initialScale.x, aScale.x, t), Mathf.Lerp(initialScale.y, aScale.y, t));
			transform.localScale = newScale;
			yield return null;
		}
	}
}
