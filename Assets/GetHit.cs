using UnityEngine;
using System.Collections;

public class GetHit : MonoBehaviour {
	KeepScore score;

	public bool isTrap = false;
	public bool isWipeoutBonus = false;
	
	void Start () {
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));
	}
	
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!score.timeUp){
			Camera.main.GetComponent<Shake>().ApplyShake(1.0f);
			BonusLifecycle bl = (BonusLifecycle)GameObject.Find("ObstacleManager").GetComponent<BonusLifecycle>();


			if(isWipeoutBonus){
				bl.CollectWipeoutBonus(gameObject);
				return;
			} 

			if(isTrap){
				bl.ApplyPenalty(gameObject);
				GetComponent<Shatter>().StartShatter(collision.gameObject.GetComponent<PushAndPull>().currentVelocity);
				return;
			}

			GetComponent<Shatter>().StartShatter(collision.gameObject.GetComponent<PushAndPull>().currentVelocity);

			// if its not a trap or a wipeout bonus it's a classic bonus
			bl.CollectBonus(gameObject);
		}
	}
}
