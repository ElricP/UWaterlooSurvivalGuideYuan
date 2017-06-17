using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	private string Username;
	private string Password;
	private string LoginMessage;
	// Use this for initialization
	void Start () {
		
	}

	public void LoginButton() {
		print ("Login Successful");
		Application.LoadLevel ("MainMenu");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;

		
	}
}
