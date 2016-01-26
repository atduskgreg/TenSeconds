using UnityEngine;
using System.Collections;

public class BringUpHighScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("ScorePanel").GetComponent<Bounce>().DoBounce();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
