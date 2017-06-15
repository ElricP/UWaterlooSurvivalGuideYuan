using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public int speed = 10000;
	Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical")) * speed;
		Vector3 lookVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2"),90);//arbitrary large constant to negate rotation on z axis
		body.MovePosition (transform.position.toVector2() + moveVec);
		if (lookVec.x != 0 && lookVec.y != 0) {
			transform.rotation = Quaternion.LookRotation (lookVec,Vector3.back);
		} else if (moveVec.x != 0 && moveVec.y != 0){
			Vector3 moveLookVec = new Vector3 (moveVec.x/speed, moveVec.y/speed, 9999);
			transform.rotation = Quaternion.LookRotation(moveLookVec, Vector3.back);
		}
	}
}
