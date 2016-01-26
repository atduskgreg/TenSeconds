using UnityEngine;
using System.Collections;

public class SelectSprite : MonoBehaviour {
	public Sprite bonusSprite;
	public Sprite penaltySprite;
	public Sprite killBonusSprite;

	public SpriteRenderer splashSprite;


	void Start () {
	}

	public void BeBonus(){
		splashSprite.sprite = bonusSprite;
		splashSprite.GetComponent<FallToLocation>().Begin();
	}
	
	public void BePenalty(){

		splashSprite.sprite = penaltySprite;
		splashSprite.GetComponent<FallToLocation>().Begin();

	}

	public void BeKillBonus(){
		splashSprite.sprite = killBonusSprite;
		splashSprite.GetComponent<FallToLocation>().Begin();
	}

	void Update () {
	
	}
}
