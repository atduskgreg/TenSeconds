using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {
	GameObject player;
	public float maxSpeed = 0.075f;
	public float minSpeed = 0.01f;
	public float timeToMaxSpeed = 4.0f;

	public float speedUpPerLevel = 0.05f; 
	public GameObject glow;
	public Sprite upgradedGlow;

	int speedLevel = 0;

	KeepScore score;
	BonusLifecycle bonusLifecycle;
	
	void Start () {
		player = GameObject.Find("player");
		bonusLifecycle = GameObject.Find("ObstacleManager").GetComponent<BonusLifecycle>();
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));

		minSpeed += Random.Range(-0.015f, 0.005f);
		maxSpeed += Random.Range(-0.08f, 0.01f);
	}

	public void SetSpeedLevel(int l){
		speedLevel = l;
		print ("speedLevel: " + speedLevel);
		if(speedLevel < 1){
			glow.SetActive (false);
		} else {
			if(speedLevel > 2){
				glow.GetComponent<SpriteRenderer>().sprite = upgradedGlow;
			}
			glow.SetActive(true);
		}
	}
	
	void Update () {
		if(!score.timeUp){
			float elapsed = Time.time - bonusLifecycle.lastBonusTime;

			float newMaxSpeed = maxSpeed + speedUpPerLevel * speedLevel;

			float speed = Mathf.Clamp(elapsed.Remap(0, timeToMaxSpeed, minSpeed, newMaxSpeed), minSpeed, newMaxSpeed);


			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
		}
	}
}
