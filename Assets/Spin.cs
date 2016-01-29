using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float spinSpeed = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0,0,spinSpeed * Time.deltaTime);
	}
}
