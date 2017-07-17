using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Image> ().fillAmount = 
			//GameObject.Find("Player").GetComponent<PlayerController>().currentHealth/GameObject.Find("Player").GetComponent<PlayerController>().maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Image> ().fillAmount = 
			GameObject.Find("Player").GetComponent<PlayerController>().currentHealth/GameObject.Find("Player").GetComponent<PlayerController>().maxHealth;
		
	}
}
