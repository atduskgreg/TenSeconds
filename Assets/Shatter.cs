using UnityEngine;
using System.Collections;

public class Shatter : MonoBehaviour {
	public GameObject shardParent;

	public float smashTransfer = 0.004f;
	public float explodeAmount = 0.1f;


	public void StartShatter(Vector2 smashDir){

		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
		GameObject shards = (GameObject)Instantiate(shardParent, new Vector3(transform.position.x , transform.position.y, transform.position.z), Quaternion.identity);

		float aveX = 0.0f;
		float aveY = 0.0f;
		int numShards = 0;
		foreach(Transform shard in shards.transform){
			aveX += shard.position.x;
			aveY += shard.position.y;
			numShards++;
		}

		Vector2 center = new Vector2(aveX/numShards, aveY/numShards);
		
		foreach(Transform shard in shards.transform){


			if(shard.GetComponentInParent<Rigidbody2D>()){
				shard.GetComponentInParent<Rigidbody2D>().AddForce( smashDir * smashTransfer, ForceMode2D.Impulse );

				Vector2 dirFromCenter = (Vector2)shard.position - center;//shardParent.transform.position;

				shard.GetComponentInParent<Rigidbody2D>().AddForce( dirFromCenter * explodeAmount, ForceMode2D.Impulse );
			}

		}
	}

	void Start () {
	
	}
	
	void Update () {
	
	}
}
