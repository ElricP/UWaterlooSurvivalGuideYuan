using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttackController : MonoBehaviour {

	public int speed;
	Vector2 currentVelocity;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		GameObject player = GameObject.Find ("Player");
		Vector3 dir = player.transform.position - GetComponent<Transform>().position;
		Vector2 startVelocity = new Vector2 (dir.x, dir.y)* speed;//new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2")) * speed;

		body.velocity = startVelocity;
		currentVelocity = startVelocity;
	}

	// Update is called once per frame
	void Update () {
		body.velocity = currentVelocity;
	}

	void OnCollisionEnter2D(Collision2D collider) {
		//Debug.Log("Collision Detected");
		if (collider.gameObject.layer == 8 ||collider.gameObject.tag == "Player") { //layer terrian is 9
			Destroy (gameObject);
		} else {
		}
	}
}
