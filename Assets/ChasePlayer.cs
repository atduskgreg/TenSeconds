using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {
	GameObject player;
	public float maxSpeed = 0.075f;
	public float minSpeed = 0.01f;
	public float timeToMaxSpeed = 4.0f;
	KeepScore score;
	BonusLifecycle bonusLifecycle;




	void Start () {
		player = GameObject.Find("player");
		bonusLifecycle = GameObject.Find("ObstacleManager").GetComponent<BonusLifecycle>();
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));

		minSpeed += Random.Range(-0.015f, 0.005f);
		maxSpeed += Random.Range(-0.08f, 0.01f);
	}
	
	void Update () {
		if(!score.timeUp){
			float elapsed = Time.time - bonusLifecycle.lastBonusTime;

			float speed = Mathf.Clamp(elapsed.Remap(0, timeToMaxSpeed, minSpeed, maxSpeed), minSpeed, maxSpeed);
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
		}
	}
}
