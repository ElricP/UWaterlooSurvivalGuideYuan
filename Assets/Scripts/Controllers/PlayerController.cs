using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public int speed;
	public float attackSpeed;
	public float abilityCooldown;
	Rigidbody2D body;
	Transform gun;
	public GameObject bullet;
	public bool abilityReady = true;
	private float nextFire = 0.0F;
	private Vector2 facingDirection;
	private int speedMultiplier = 10000;
	private float abilityDuration = 10F;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		gun = transform.Find ("Gun");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical")) * speed;
		Vector3 shootVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2"),90);//arbitrary large constant to negate rotation on z axis
		body.MovePosition (transform.position.toVector2() + moveVec); //moving command
		if (shootVec.x != 0 || shootVec.y != 0) { //shooting command
			transform.rotation = Quaternion.LookRotation (shootVec,Vector3.back); //player's rotation while shooting
			facingDirection = shootVec.toVector2();
			if (Time.time > nextFire) {
				Fire ();
				nextFire = Time.time + (1 / attackSpeed);
			}
		} else if (moveVec.x != 0 || moveVec.y != 0){ //player's rotation while not shooting
			Vector3 moveLookVec = new Vector3 (moveVec.x/speed, moveVec.y/speed, 9999);
			transform.rotation = Quaternion.LookRotation(moveLookVec, Vector3.back);
			facingDirection = moveVec/speed;
		}
		if(CrossPlatformInputManager.GetButton("AbilityButton") && abilityReady){
			StartCoroutine ("UseAbility");
			nextFire = Time.time;
		}
	}

	void Fire(){
		Instantiate (bullet, gun.position,Quaternion.identity);
	}

	IEnumerator UseAbility(){ //prototype gets shadowstep ability
		abilityReady = false;
		GameObject.Find ("AbilityButton").SetActive (false);
		speed = speed * speedMultiplier;
		yield return new WaitForSecondsRealtime(abilityDuration);
		speed = speed/speedMultiplier;

		yield return new WaitForSecondsRealtime (abilityCooldown);
		abilityReady = true;
		GameObject.Find ("AbilityButton").SetActive (true);
	}

	public bool AbilityReady(){
		return abilityReady;
	}
}
