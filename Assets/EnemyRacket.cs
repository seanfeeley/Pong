using UnityEngine;
using System.Collections;

public class EnemyRacket : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	Vector3 move = Vector3.zero;
	float speed = 6.0f;
	
	void Update(){
		Transform ball;
		ball = ((Ball)(FindObjectOfType (typeof(Ball))) as Ball).transform;
		float d = ball.position.z - transform.position.z;	
		transform.rotation = Quaternion.identity;
		
		if(d > 0){	
			move.z = speed * Mathf.Min(d, 1.0f);
			transform.Rotate(new Vector3(0,2f,0));
			
		}
		if(d < 0){
			move.z = -(speed * Mathf.Min(-d, 1.0f));
			transform.Rotate(new Vector3(0,-2f,0));
			
		}

		transform.position += move * Time.deltaTime;
		transform.position = new Vector3(23.5f,0.0f,Mathf.Clamp (transform.position.z, -16, 16));

		if (transform.position.z == 16 || transform.position.z == -16) {
			transform.rotation = Quaternion.identity;
				}
						

	}

	void FixedUpdate(){



	}
}
