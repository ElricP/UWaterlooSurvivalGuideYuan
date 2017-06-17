using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public int speed = 10000;
	public float attackSpeed;
	Rigidbody2D body;
	Transform gun;
	public GameObject bullet;
	private float nextFire = 0.0F;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		gun = transform.Find ("Gun");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical")) * speed;
		Vector3 shootVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2"),90);//arbitrary large constant to negate rotation on z axis
		body.MovePosition (transform.position.toVector2() + moveVec);
		if (shootVec.x != 0 || shootVec.y != 0) {
			transform.rotation = Quaternion.LookRotation (shootVec,Vector3.back); //player's rotation
			if (Time.time > nextFire) {
				Fire ();
				nextFire = Time.time + (1 / attackSpeed);
			}
		} else if (moveVec.x != 0 || moveVec.y != 0){
			Vector3 moveLookVec = new Vector3 (moveVec.x/speed, moveVec.y/speed, 9999);
			transform.rotation = Quaternion.LookRotation(moveLookVec, Vector3.back);
		}
	}

	void Fire(){
		Instantiate (bullet, gun.position,Quaternion.identity);
	}

}
