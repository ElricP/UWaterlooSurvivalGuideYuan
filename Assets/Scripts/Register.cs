using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;	
	public GameObject password;
	public GameObject confirmPassword;
	private string Username;
	private string Email;
	private string Password;
	private string ConfirmPassword;
	private bool EmailValid;
	private string RegisterMessage;

	// Use this for initialization
	void Start () {
		EmailValid = false;
		RegisterMessage = "";

	}

	public void RegisterButton (){
		print ("Registration Successful");
		Application.LoadLevel ("MainMenu");

	}



	// Update is called once per frame
	void Update () {
		Username = username.GetComponent<InputField> ().text;
		Email = email.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
		ConfirmPassword = confirmPassword.GetComponent<InputField> ().text;
	}
}