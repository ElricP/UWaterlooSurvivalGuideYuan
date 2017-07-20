using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactoryManager : MonoBehaviour {
	[SerializeField]
	private GameObject[] characters;
	private int currentSelected = 0;
	// Use this for initialization
	void Awake () {
		currentSelected = Account.account.GetCurrentCharacter ();
		Instantiate (characters [currentSelected], gameObject.transform.position, Quaternion.identity).gameObject.name = "Player";
		GameObject.Find ("Player").SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
