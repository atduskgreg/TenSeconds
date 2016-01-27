using UnityEngine;
using System.Collections;

public class ShowPlayer : MonoBehaviour {

	public GameObject player;
	public bool shouldShowPlayer = true;

	void Start () {
		player.SetActive(false);
	}
	
	void Update () {
		if(shouldShowPlayer && GameObject.Find("ScorePanel").GetComponent<Bounce>().isComplete() && GameObject.Find("ScorePanel").transform.position.y < -6.0f){
			player.SetActive(true);
		}
	}
}
