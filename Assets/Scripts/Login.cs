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
		List<bool> UnlockedC = new List<bool> (new bool[] {true,true,true,false,false,false,false,false,false});
		List<bool> UnlockedI = new List<bool> (new bool[] {true,true,true,false,false,false,false,false,false});
		Account.account.Setup (100, 100, 100000000, 100000000, 0, Username, 1, 1, UnlockedC, UnlockedI);
		print ("Login Successful");
		Application.LoadLevel ("MainMenu");
	}

	// Update is called once per frame
	void Update () {
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;

		
	}
}
