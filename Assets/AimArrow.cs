using UnityEngine;
using System.Collections;

public class AimArrow : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		transform.RotateAround()
		transform.position = player.transform.position;


	}
}
