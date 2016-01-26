using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public float signAnimationTime = 0.5f;
	GameObject scorePanel;

	void Start () {
		scorePanel = GameObject.Find("ScorePanel");
	}
	
	void Update () {
	}
	
	public void ClickToStart(){
		print ("ClickToStart()");
		StartCoroutine(BounceTo (new Vector2(scorePanel.transform.position.x, -8.25f), signAnimationTime));
	}
	
	IEnumerator BounceTo(Vector2 targetPos, float time){
		Vector2 startPos = scorePanel.transform.position;
		for (float t = 0.0f; t < time; t += Time.deltaTime ){
			float y = (float)Easing.ElasticEaseInOut(t, startPos.y, targetPos.y - startPos.y, time);
			scorePanel.transform.position = new Vector2(scorePanel.transform.position.x, y);
			yield return null;
		}
		GameObject.Find("TimerWidget").GetComponent<Bounce>().DoBounce();
	}
}
