using UnityEngine;
using System.Collections;

public class AlignWithLeftEdge : MonoBehaviour {
	 
	void Start () {
		Vector3 before = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		Vector3 p = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
		transform.position = new Vector3(p.x, before.y, 3.5f);
	}
	
	void Update () {
	
	}
}
