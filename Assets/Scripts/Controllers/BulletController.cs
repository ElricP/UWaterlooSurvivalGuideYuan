using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BulletController : MonoBehaviour {
	public int speed;
	Vector2 currentVelocity;
	Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		Vector2 startVelocity = new Vector2 (CrossPlatformInputManager.GetAxis("Horizontal2"),CrossPlatformInputManager.GetAxis("Vertical2")) * speed;//new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2")) * speed;

		body.velocity = startVelocity;
		currentVelocity = startVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = currentVelocity;
	}

	void OnCollisionEnter2D(Collision2D collider) {
		//Debug.Log("Collision Detected");
		if (collider.gameObject.layer == 9) { //layer terrian is 9
			Destroy (gameObject);
		} else {
		}
	}
}
