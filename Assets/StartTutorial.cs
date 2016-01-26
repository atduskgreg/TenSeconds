using UnityEngine;
using System.Collections;

public class StartTutorial : MonoBehaviour {

	public void GoToTutorial(){
		Application.LoadLevel("Tutorial1");
	}
}
