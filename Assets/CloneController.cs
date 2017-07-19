using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CloneController : PlayerController {
	private GameObject player;
	// Use this for initialization
	void Start () {
		maxHealth = 30f;
		currentHealth = 30f;
		body = this.GetComponent<Rigidbody2D> ();
		gun = transform.Find ("Gun");
		invincible = false;

		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Die ();
		}
		Vector3 shootVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2"), 90);
		Vector3 dir = player.transform.position - GetComponent<Transform>().position;
		dir.z = 0;

		if (shootVec.x != 0 || shootVec.y != 0) { //shooting command
			transform.rotation = Quaternion.LookRotation (shootVec, Vector3.back); //clone's rotation while shooting
			if (Time.time > nextFire) {
				Fire ();
				nextFire = Time.time + (1 / attackSpeed);
			}
		}
		// clones follow player but not too close
		if ((dir.x * dir.x + dir.y * dir.y) > 110000) {
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
		}
	}

	public void OnCollisionEnter2D (Collision2D item) {

		if (item.gameObject.tag == "Bullet") {
			Physics2D.IgnoreCollision(item.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
		} 
		else if ((item.gameObject.tag == "Goose" || item.gameObject.tag == "WaveBullet") && !invincible) {
			Debug.Log("Goose attack");
			currentHealth = currentHealth - damage;
		} 

	}

	public void Die(){
		Destroy (gameObject);
	}
}
