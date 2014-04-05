using UnityEngine;
using System.Collections;
using System;

public class Ball : MonoBehaviour {
	// Use this for initialization
	private Vector3 direction;
	private float speed;
	
	public int player_score=0;
	public int cpu_score=0;
	void Start () {
		// set start direction
		this.direction = new Vector3(1.0f, 0.0f, 0.0f).normalized;
		this.speed = 0.3f;
		
	}
	// Update is called once per frame
	void Update () {
		// keep speed of 1
		this.transform.position += direction * speed;
		
	
	}

	void reset(String who){

		if (who == "player") {
						this.direction = new Vector3 (-1.0f, 0.0f, 0.0f).normalized;
				}
		else{
			this.direction = new Vector3 (1.0f, 0.0f, 0.0f).normalized;
		}
		this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
		print("HELLA "+who);
		}

	void OnCollisionEnter(Collision collision){
		Vector3 normal = collision.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
		this.speed = this.speed + 0.01f;
		//inverse velocity
//		rigidbody.velocity = rigidbody.velocity * -2.0f;
		if (collision.collider.name == "BorderLeft"){
			player_score=player_score+1;
			reset ("player");
		}
		else if (collision.collider.name == "BorderRight"){
			cpu_score=cpu_score+1;
			reset("cpu");
		}
		TextMesh t = (TextMesh)(FindObjectOfType(typeof(TextMesh)));
		t.text = player_score+" : "+ cpu_score;


//		else if (collision.collider.name == "BorderTop"){
//			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z * -1.0f);
//		}
//		else if (collision.collider.name == "BorderBottom"){
//			rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z * -1.0f);
//		}
//		else if (collision.collider.name == "RacketLeft"){
//			rigidbody.velocity = new Vector3(rigidbody.velocity.x * -1.0f , rigidbody.velocity.y, rigidbody.velocity.z);
//		}
//		else if (collision.collider.name == "RacketRight"){
//			rigidbody.velocity = new Vector3(rigidbody.velocity.x * -1.0f , rigidbody.velocity.y, rigidbody.velocity.z);
//   		}

	}
}
