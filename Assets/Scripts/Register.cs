using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

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

	private Firebase.Auth.FirebaseAuth auth;
	private Firebase.Auth.FirebaseUser user;

	// Use this for initialization
	void Start () {
		EmailValid = false;
		RegisterMessage = "";
		InitializeFirebase ();
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl ("https://uwsg-4c77b.firebaseio.com/");

	}
	void InitializeFirebase() {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.StateChanged += AuthStateChanged;
		AuthStateChanged(this, null);
	}


	public void RegisterButton (){
		if (Password != ConfirmPassword) {
			return;
		}

		auth.CreateUserWithEmailAndPasswordAsync (Email, Password).ContinueWith (task => {
			if (task.IsCanceled) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync canceled");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync error" + task.Exception);
				return;
			}
			Firebase.Auth.FirebaseUser NewUser = task.Result;
			Debug.LogFormat ("Firebase user created: {0} ({1})", NewUser.DisplayName, NewUser.UserId);
		});

		auth.SignInWithEmailAndPasswordAsync(Email,Password).ContinueWith (task => {
			if (task.IsCanceled) {
				Debug.LogError ("SignInWithEmailAndPasswordAsync canceled");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError ("SignInWithEmailAndPasswordAsync error" + task.Exception);
				return;
			}

			Firebase.Auth.FirebaseUser NewUser = task.Result;
			Debug.LogFormat ("Firebase user signed in: {0} ({1})", NewUser.DisplayName, NewUser.UserId);
		});
			

			

		List<bool> UnlockedC = new List<bool> (new bool[] {true,true,true,false,false,false,false,false,false});
		List<bool> UnlockedI = new List<bool> (new bool[] {true,false,false,false,false,false,false,false,false});
		Account.account.Setup (0, 1, 500, 100, 0, Username, 0, 0, UnlockedC, UnlockedI);
		print ("gold: " + Account.account.GetGold().ToString());
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

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
		if (auth.CurrentUser != user) {
			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
			if (!signedIn && user != null) {
				Debug.LogError("Signed out " + user.UserId);
			}
			user = auth.CurrentUser;
			if (signedIn) {
				Debug.LogError("Signed in " + user.UserId);
				//displayName = user.DisplayName ?? "";
				//emailAddress = user.Email ?? "";
				//photoUrl = user.PhotoUrl ?? "";
			}
		}
	}
}