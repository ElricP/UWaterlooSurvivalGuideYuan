using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System.IO;

public class PlayerController : MonoBehaviour {

	public float maxHealth { get; protected set;}
	public float currentHealth{ get; protected set;}
	protected bool invincible;
	public int speed;
	public float attackSpeed;
	public float abilityCooldown;
	protected Rigidbody2D body;
	protected Transform gun;
	public GameObject bullet;
	public bool abilityReady = true;
	protected float nextFire = 0.0F;
	public int speedMultiplier;
	public int shadowStepBoost;

	public GameObject Boost;
	public float boostMultiplier;
	public float boostDuration;

	public GameObject HealthKit;
	public GameObject Armor;
	public float armorDuration;
	public GameObject SwiftyShoes;
	public float SwiftyShoesDuration;

	protected float damage = 5;
	protected bool died = false;
protected Vector2 facingDirection;
protected float abilityDuration = 0.5F;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		gun = transform.Find ("Gun");
		maxHealth = 100f;
		currentHealth = 100f;
		invincible = false;
	}


	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Die ();
		}
		if (!died) {
			Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical")) * speed;
			Vector3 shootVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal2"), CrossPlatformInputManager.GetAxis ("Vertical2"), 90);//arbitrary large constant to negate rotation on z axis
			body.MovePosition (transform.position.toVector2 () + moveVec); //moving command
			if (shootVec.x != 0 || shootVec.y != 0) { //shooting command
				transform.rotation = Quaternion.LookRotation (shootVec, Vector3.back); //player's rotation while shooting
				facingDirection = shootVec.toVector2 ();
				if (Time.time > nextFire) {
					Fire ();
					nextFire = Time.time + (1 / attackSpeed);
				}
			} else if (moveVec.x != 0 || moveVec.y != 0) { //player's rotation while not shooting
				Vector3 moveLookVec = new Vector3 (moveVec.x / speed, moveVec.y / speed, 9999);
				transform.rotation = Quaternion.LookRotation (moveLookVec, Vector3.back);
				facingDirection = moveVec / speed;
			}
			if (CrossPlatformInputManager.GetButton ("AbilityButton") && abilityReady) {
				StartCoroutine ("UseAbility");
				nextFire = Time.time;
			}
		}

	}
	public void Die(){
		died = true;
	}
	protected void Fire(){
		Instantiate (bullet, gun.position,Quaternion.identity);
	}

	protected IEnumerator UseAbility(){ //prototype gets shadowstep ability
		abilityReady = false;
		speed = speed * shadowStepBoost;	//apply ability effect
		int countDown = (int)abilityCooldown;
		GameObject.Find ("abilityCountDown").GetComponent<Text>().text = countDown.ToString();
		yield return new WaitForSecondsRealtime (abilityDuration);
		speed = speed/shadowStepBoost;		//end ability effect

		while(countDown > 0){ //count ability cooldown only after effect gone
			GameObject.Find ("abilityCountDown").GetComponent<Text> ().text = countDown.ToString();
			yield return new WaitForSecondsRealtime (1);	
			countDown = countDown - 1;
		}
		GameObject.Find ("abilityCountDown").GetComponent<Text> ().text = "";
		abilityReady = true;
	}

	public bool AbilityReady(){
		return abilityReady;
	}
	protected void OnCollisionEnter2D(Collision2D item) {
		// Debug.Log("Collision Detected");
		if (item.gameObject.tag == "Boost") {
			Destroy (item.gameObject);
			StartCoroutine ("ApplyBoost");
		} 
		else if (item.gameObject.tag == "HealthKit") {
			Destroy (item.gameObject);
			currentHealth = currentHealth + 10;
		} 
		else if (item.gameObject.tag == "Armor") {
			Destroy (item.gameObject);
			StartCoroutine ("ApplyBoost");
		} 
		else if (item.gameObject.tag == "SwiftyShoes") {
			Destroy (item.gameObject);
			StartCoroutine ("ApplySwiftyShoes");
		} 
		else if (item.gameObject.layer == 9 && !invincible) {
			//currentHealth = currentHealth - damage;
		} 
		else if ((item.gameObject.tag == "Goose" || item.gameObject.tag == "WaveBullet") && !invincible) {
			Debug.Log("Goose attack");
			currentHealth = currentHealth - damage;
		} 
	}

	protected IEnumerator ApplyBoost() {
		attackSpeed = attackSpeed * boostMultiplier;
		yield return new WaitForSecondsRealtime (boostDuration);
		attackSpeed = attackSpeed / boostMultiplier;
	}

	protected IEnumerator ApplyArmor() {
		float tmp = damage;
		damage = damage - 2 <= 0 ? 0 : damage - 2;
		yield return new WaitForSecondsRealtime (armorDuration);
		damage = tmp;
	}

	protected IEnumerator ApplySwiftyShoes() {
		speed = speed * speedMultiplier;
		yield return new WaitForSecondsRealtime (SwiftyShoesDuration);
		speed = speed / speedMultiplier;
	}
}
