using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScrollText : MonoBehaviour {
	[TextArea(5,10)]public string text;
	public float secondsPerCharacter = 0.5f;
	public Text[] targets;

	string[] originalTexts;
	int charOffset = 0;

	void Start () {

	}

	public void StartScrolling(){
		GetComponent<AudioSource>().Play();
		charOffset = 0;
		originalTexts = new string[targets.Length]; 
		for(int i = 0; i < targets.Length; i++){
			originalTexts[i] =  targets[i].text;
		}
		InvokeRepeating("DoScroll", 0, secondsPerCharacter);
	}

	void DoScroll(){
		bool allDoneScrolling = false;
		for(int i = 0; i < targets.Length; i++){
			string txt = originalTexts[i] + "_" + text + "_" + originalTexts[i].PadLeft(8, '_');
			if(charOffset + 8 <= txt.Length){
				targets[i].text = txt.Substring(charOffset, 8);
			} else {
				allDoneScrolling = true;
			}
		}
		if(!allDoneScrolling){
			charOffset++;
		} else {
			for(int i = 0; i < targets.Length; i++){
				targets[i].text = originalTexts[i];
			}
			CancelInvoke("DoScroll");
		}
		
	}

}
