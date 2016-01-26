using UnityEngine;
using System.Collections;

public class UpdateWipeoutDisplay : MonoBehaviour {
	public GameObject wipeoutIcon;

	BonusLifecycle bonusLifecycle;

	// Use this for initialization
	void Start () {
		if(GameObject.Find("ObstacleManager")){
			bonusLifecycle = (BonusLifecycle)GameObject.Find("ObstacleManager").GetComponent(typeof(BonusLifecycle));
			Refresh();
		}
	}

	public void Refresh(){
		for (int i = transform.childCount - 1; i >= 0; i--){
			Destroy(transform.GetChild(i).gameObject);

		}

		for(int i = 0; i < bonusLifecycle.GetNumWipeouts(); i++){
			Vector2 pos = new Vector2(transform.position.x + i/3.0f, transform.position.y);
			GameObject bonus = (GameObject)Instantiate(wipeoutIcon, pos, Quaternion.identity);
			bonus.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
