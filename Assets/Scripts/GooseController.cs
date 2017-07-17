using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseController : MonoBehaviour {
	public float speed;
	public GameObject player;
	public float health = 25;
	//private Rigidbody2D rb;
	// attack sound effect
	private AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		//rb = GetComponent<Rigidbody2D>();
		//player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		player = GameObject.Find ("Player");
		Vector3 dir = player.transform.position - GetComponent<Transform>().position;
		dir.z = 0;

		// goose follow player
		if ((dir.x * dir.x + dir.y * dir.y) > 110000) {
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
		}

		if ((dir.x * dir.x + dir.y * dir.y) > 600000) {
			//aud.Stop ();
		} else if (!aud.isPlaying) {
			aud.Play ();
			aud.loop = false;
		}

		if (dir.y > 0) {
			transform.localRotation = Quaternion.Euler(0, 180, 0);
		} else if (dir.y < 0) {
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}

	}

	void OnCollisionEnter2D(Collision2D collider) {		
		if (collider.gameObject.tag == "Bullet") { //bullet
			Debug.Log("Collision Detected on goose");
			health -= 5;
		} else {
			
		}

		if (health <= 0) {
			// call random generate item
			// call killed goose counter
			Destroy (gameObject);
		}
	}
}
