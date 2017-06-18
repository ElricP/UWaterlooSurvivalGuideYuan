using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButtonAnimatorController : MonoBehaviour {
	private bool ready;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		ready = playerController.AbilityReady ();
		GameObject.Find ("AbilityButton").GetComponent<Animator> ().SetBool("AbilityReady",ready);
	}

}
