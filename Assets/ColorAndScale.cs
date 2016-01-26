using UnityEngine;
using System.Collections;



public class ColorAndScale : MonoBehaviour {
	public GameObject player;
	Vector3 originalScale;
	float lastClickTime = 0;
	public float clickOffset = 2.0f;
	public float clickAnimTime = 0.33f;

	void Start () {
//		gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		originalScale = transform.localScale;
	}
	
	void Update () {
		Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);        //Mouse position
		Vector3 objpos = Camera.main.WorldToViewportPoint (transform.position);        //Object position on screen
		Vector2 relobjpos = new Vector2(objpos.x - 0.5f,objpos.y - 0.5f);            //Set coordinates relative to object
		Vector2 relmousepos = new Vector2 (mouse.x - 0.5f,mouse.y - 0.5f) - relobjpos;
		float angle = Vector2.Angle (Vector2.up, relmousepos);    //Angle calculation
		if (relmousepos.x > 0){
			angle = 360-angle;
		}
		
		Quaternion quat = Quaternion.identity;
		quat.eulerAngles = new Vector3(0,0,angle); //Changing angle
		transform.rotation = quat;

		float dist = Vector3.Distance(Input.mousePosition, Camera.main.WorldToScreenPoint(player.transform.position));//mouseDir.magnitude;
		float maxD = Mathf.Sqrt(Mathf.Pow(Screen.width,2) + Mathf.Pow(Screen.height, 2)) / 2.0f;

		float yOffsetFalloff = Mathf.Clamp(Mathf.Lerp (0, clickOffset, clickAnimTime - (Time.time - lastClickTime)), 0, clickOffset);
	
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffsetFalloff, player.transform.position.z);

		transform.localScale = originalScale * dist.Remap(0, maxD, 0.3f, 2.0f);

		if(player.GetComponent<PushAndPull>().isPushing){

			transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1.0f);

		} else {

			transform.position = Vector3.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 0f);
		}



		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, 8), Mathf.Clamp(transform.position.y, -4, 4), 0);


	}

	public void Bump(){
		lastClickTime = Time.time;

	}
}
