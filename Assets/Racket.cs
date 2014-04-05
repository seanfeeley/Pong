using UnityEngine;
using System.Collections;



public class Racket : MonoBehaviour {

	public KeyCode key_up;
	public KeyCode key_down;
	public Transform paddle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}
	
	void FixedUpdate(){
		Vector3 pos= transform.position;
		transform.rotation = Quaternion.identity;
		if (Input.GetKey(key_up)){
			//up
			transform.position=new Vector3(pos.x,pos.y,Mathf.Clamp( pos.z+0.2f, -6, 6 ));
			transform.Rotate(new Vector3(0,-2f,0));
		}
		else if (Input.GetKey(key_down)){
			//down
			transform.position=new Vector3(pos.x,pos.y,Mathf.Clamp( pos.z-0.2f, -6, 6 ));
			transform.Rotate(new Vector3(0,2f,0));
			
			
		}


	}
}
