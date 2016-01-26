using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	void Start () {
		transform.rotation = Quaternion.AngleAxis(Random.Range(0,360), Vector3.forward);
	}
	
	void Update () {
	
	}
}
