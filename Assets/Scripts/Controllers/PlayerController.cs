using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float maxHealth { get; private set;}
	public float currentHealth{ get; private set;}
	private bool invincible;
	public int speed;
	public float attackSpeed;
	public float abilityCooldown;
	Rigidbody2D body;
	Transform gun;
	public GameObject bullet;
	public bool abilityReady = true;
	private float nextFire = 0.0F;
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

	private float damage = 5;
private Vector2 facingDirection;

private float abilityDuration = 0.5F;
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
	void OnCollisionEnter2D(Collision2D item) {
		//Debug.Log("Collision Detected");
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
			currentHealth = currentHealth - damage;
		}
	}

	IEnumerator ApplyBoost() {
		attackSpeed = attackSpeed * boostMultiplier;
		yield return new WaitForSecondsRealtime (boostDuration);
		attackSpeed = attackSpeed / boostMultiplier;
	}

	IEnumerator ApplyArmor() {
		float tmp = damage;
		damage = damage - 2 <= 0 ? 0 : damage - 2;
		yield return new WaitForSecondsRealtime (armorDuration);
		damage = tmp;
	}

	IEnumerator ApplySwiftyShoes() {
		speed = speed * speedMultiplier;
		yield return new WaitForSecondsRealtime (SwiftyShoesDuration);
		speed = speed / speedMultiplier;
	}
}
