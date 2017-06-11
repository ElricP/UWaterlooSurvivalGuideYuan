using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEditor.SceneManagement;

public class Register : MonoBehaviour {
	public GameObject username;
	public GameObject email;	
	public GameObject password;
	public GameObject confirmPassword;
	private string Username;
	private string Email;
	private string Password;
	private string ConfirmPassword;
	private bool emailValid = false;

	// Use this for initialization
	void Start () {
		
	}

	public void RegisterButton (){
		print ("Registration Successful");
		Application.LoadLevel ("MainMenu");

	}
		

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				email.GetComponent<InputField> ().Select ();
			}
			if (email.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
			if (password.GetComponent<InputField> ().isFocused) {
				confirmPassword.GetComponent<InputField> ().Select ();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Email = email.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
		ConfirmPassword = confirmPassword.GetComponent<InputField> ().text;
	}
}
