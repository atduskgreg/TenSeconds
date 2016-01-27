using UnityEngine;
using System.Collections;

public class GetHitTutorial : MonoBehaviour {

	public bool isTrap = false;
	public bool isWipeoutBonus = false;
	public bool collected = false;
	
	void Start () {
//		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));
	}
	
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Camera.main.GetComponent<Shake>().ApplyShake(1.0f);
		BonusLifecycle bl = (BonusLifecycle)GameObject.Find("ObstacleManager").GetComponent<BonusLifecycle>();

		if(isTrap){
			GetComponent<Shatter>().StartShatter(collision.gameObject.GetComponent<PushAndPull>().currentVelocity);
			bl.ApplyPenalty(gameObject);
		} else if(isWipeoutBonus){

			bl.CollectWipeoutBonus(gameObject);
		} else{
			GetComponent<Shatter>().StartShatter(collision.gameObject.GetComponent<PushAndPull>().currentVelocity);

			bl.CollectBonusTutorial(gameObject);
		}
		collected = true;


	}
}
