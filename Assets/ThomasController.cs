using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThomasController : PlayerController {
	[SerializeField]
	private GameObject clone;
	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		gun = transform.Find ("Gun");
		maxHealth = 200f;
		currentHealth = 200f;

		invincible = false;
	}

	IEnumerator UseAbility(){ //Thomas uses thread fork to get a clone
		abilityReady = false;
		Instantiate (clone, transform.position, Quaternion.identity);
		int countDown = (int)abilityCooldown;
		GameObject.Find ("abilityCountDown").GetComponent<Text>().text = countDown.ToString();
		yield return new WaitForSecondsRealtime (abilityDuration);


		while(countDown > 0){ //count ability cooldown only after effect gone
			GameObject.Find ("abilityCountDown").GetComponent<Text> ().text = countDown.ToString();
			yield return new WaitForSecondsRealtime (1);	
			countDown = countDown - 1;
		}
		GameObject.Find ("abilityCountDown").GetComponent<Text> ().text = "";
		abilityReady = true;
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
		} else if (item.gameObject.tag == "Bullet") {
			Physics2D.IgnoreCollision(item.gameObject.GetComponent<CircleCollider2D>(), gameObject.GetComponent<CircleCollider2D>());
		} 
	}

}
