using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

//	float lastClickTime = 0;
	public float clickOffset = 0.1f;
	public float clickAnimTime = 0.33f;
	Vector3 startingPosition;

	// Use this for initialization
	void Start () {
//		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		float yOffsetFalloff = Mathf.Clamp(Mathf.Lerp (0, clickOffset, clickAnimTime - (Time.time - lastClickTime)), 0, clickOffset);
		
		//		print ("yOffsetFalloff: " + yOffsetFalloff);

//		transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z);
//		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yOffsetFalloff, transform.localPosition.z);

	
	}

	public void Clicked(){
//		lastClickTime = Time.time;
	}
}
