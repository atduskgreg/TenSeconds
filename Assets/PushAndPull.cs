using UnityEngine;
using System.Collections;

public class PushAndPull : MonoBehaviour {
	public bool isPushing;
	public float pushPercent = 5;
	public GameObject arrow;

	public Animator animator;

	public Vector2 currentVelocity;

	KeepScore score;

	// Use this for initialization
	void Start () {
		score = (KeepScore)GameObject.Find("progress_bar").GetComponent(typeof(KeepScore));
		animator.StopPlayback();

	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKey(KeyCode.Space)){
//			isPushing = true;
//		} else {
			isPushing = false;
//		}

		Vector3 pushDir;
		if(Input.GetMouseButtonDown(0) && score.GameOn()){


			pushDir = Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition;
			
			pushDir *= pushPercent;
			pushDir *= -1;

			
//			if(isPushing){
//			} else {
//				pushDir *= -1;
//			}
			GetComponent<Rigidbody2D>().AddForce(pushDir);
			animator.Play("ArrowGradientAnimation", 0, 0);


			AudioSource audioSource = gameObject.GetComponent<AudioSource>();
			audioSource.Play();
			arrow.transform.GetComponentInParent<ColorAndScale>().Bump ();
		}
	}

	void FixedUpdate(){
		currentVelocity = GetComponent<Rigidbody2D>().velocity;
	}

}
