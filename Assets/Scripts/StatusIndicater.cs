using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class StatusIndicater : MonoBehaviour {
	public Material[] materials;
	public Renderer rend;

	private int index = 0;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	/*void Update () {
		if (GameObject.Find ("Player").GetComponent("abilityReady") && CrossPlatformInputManager.GetButton("AbilityButton")) {
			index = 0;
		}
		if (!GameObject.Find ("Player").GetComponent("abilityReady")) {
			index = 2;
		} else if (!CrossPlatformInputManager.GetButton ("AbilityButton")) {
			index = 1;
		}
		rend.material = materials [index];
		print (index);
	}*/
}
