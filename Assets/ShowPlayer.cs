using UnityEngine;
using System.Collections;

public class ShowPlayer : MonoBehaviour {

	public GameObject player;

	void Start () {
		player.SetActive(false);

	}
	
	void Update () {
		if(GameObject.Find("ScorePanel").GetComponent<Bounce>().isComplete() && GameObject.Find("ScorePanel").transform.position.y < -6.0f){
			player.SetActive(true);
		}
	}
}
