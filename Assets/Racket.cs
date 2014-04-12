using UnityEngine;
using System.Collections;



public class Racket : MonoBehaviour {

	public KeyCode key_up;
	public KeyCode key_down;
	public Transform paddle;
	public float move_speed=0.0f;
	public float move_speed_change=0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void FixedUpdate(){
		Vector3 pos= transform.position;
		transform.rotation = Quaternion.identity;
		if (Input.GetKey (key_up)) {
						if (move_speed <= 0) {
								move_speed = move_speed_change;
						}

						//up
						transform.position = new Vector3 (pos.x, pos.y, Mathf.Clamp (pos.z + move_speed, -16, 16));
						transform.Rotate (new Vector3 (0, move_speed * -5, 0));
						move_speed = move_speed + move_speed_change;
			

				} else if (Input.GetKey (key_down)) {
						if (move_speed >= 0) {
								move_speed = -move_speed_change;
						}
						//down
						transform.position = new Vector3 (pos.x, pos.y, Mathf.Clamp (pos.z + move_speed, -16, 16));
						transform.Rotate (new Vector3 (0, move_speed * -5, 0));
						move_speed = move_speed - move_speed_change;
			
				} else {
			move_speed=0.0f;
				}

		if (pos.z == 16 || pos.z == -16) {
			transform.rotation=Quaternion.identity;		
		}
	}
}
