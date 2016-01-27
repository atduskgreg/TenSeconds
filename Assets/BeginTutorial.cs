using UnityEngine;
using System.Collections;

public class BeginTutorial : MonoBehaviour {

	void Start () {
		// trigger timer animation
		// then make player not kinematic and display first tutorial point
		GameObject.Find ("TimerWidget").GetComponent<Bounce>().DoBounce();
	}
	
	void Update () {
		if(GameObject.Find ("TimerWidget").GetComponent<Bounce>().isComplete()){
			GameObject.Find("player").GetComponent<Rigidbody2D>().isKinematic = false;
		}
	}
}
