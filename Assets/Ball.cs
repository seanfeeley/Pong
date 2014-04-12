using UnityEngine;
using System.Collections;
using System;
using System;

public class Ball : MonoBehaviour {
	// Use this for initialization
	private Vector3 direction;
	private float speed;
	private GameObject looser;
	private GameObject ball;
	public int player_score=0;
	public int cpu_score=0;
	public int winning_score=3;
	void Start () {
		// set start direction
		this.direction = new Vector3(1.0f, 0.0f, 0.0f).normalized;
		this.speed = 0.3f;
		
	}
	// Update is called once per frame
	void Update () {
		// keep speed of 1
		if (player_score < winning_score && cpu_score < winning_score) {
						this.transform.position += direction * speed;
				}
		
	
	}

	void reset(String who){
		GameObject spload;
		if (player_score <= winning_score && cpu_score<=winning_score)
		{

			spload = Instantiate(Resources.Load("zexplosion"), this.transform.position, this.transform.rotation) as GameObject;
//			
			if (who == "player") {
							this.direction = new Vector3 (-1.0f, 0.0f, 0.0f).normalized;
					}
			else{
				this.direction = new Vector3 (1.0f, 0.0f, 0.0f).normalized;
			}
			this.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
			this.speed = 0.3f;
		}
		if (player_score==winning_score)
		{
			looser=GameObject.FindWithTag("enemy");
//			looser.audio.Play ();
			spload = Instantiate(Resources.Load("yexplosion"), looser.transform.position, looser.transform.rotation) as GameObject;
			spload = Instantiate(Resources.Load("winText")) as GameObject;
			Destroy (looser);
		}
		
		if (cpu_score==winning_score)
		{
			looser=GameObject.FindWithTag("Player");
//			looser.audio.Play ();
			spload = Instantiate(Resources.Load("yexplosion"), looser.transform.position, looser.transform.rotation) as GameObject;
			spload = Instantiate(Resources.Load("loseText")) as GameObject;
			Destroy (looser);
		}


		}


	void OnCollisionEnter(Collision collision){

		AudioSource[] audios = GetComponents<AudioSource>();
//		audios [1].Play ();
		Vector3 normal = collision.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
		this.speed = this.speed + 0.01f;
		//inverse velocity
//		rigidbody.velocity = rigidbody.velocity * -2.0f;
		if (collision.collider.name == "BorderLeft") {
						player_score = player_score + 1;
						reset ("player");
				} 
		else if (collision.collider.name == "BorderRight") {
						cpu_score = cpu_score + 1;
						reset ("cpu");
				} 
		else {
			audio.Play ();
				}

		GameObject a = GameObject.Find ("scoreText");
		TextMesh textMesh = (TextMesh) a.GetComponent (typeof(TextMesh));
		textMesh.text = player_score+" : "+ cpu_score;


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
