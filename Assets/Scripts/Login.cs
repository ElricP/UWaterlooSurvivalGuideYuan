using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;

public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	private string Username;
	private string Password;
	private string LoginMessage;

	public GameObject debugText;
	private string DebugLog;

	private Firebase.Auth.FirebaseAuth auth;
	private Firebase.Auth.FirebaseUser user;

	// Use this for initialization
	void Start () {
		InitializeFirebase ();
	}

	void InitializeFirebase() {
		auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.StateChanged += AuthStateChanged;
		AuthStateChanged(this, null);
	}

	public void LoginButton() {
		
		auth.SignInWithEmailAndPasswordAsync(Username,Password).ContinueWith (task => {
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

		GameObject tmp = GameObject.Find ("debugText");
		cvsDebug cvsdebug = tmp.GetComponent<cvsDebug> ();
		if (Password == "" || Username == "") {
			cvsdebug.debugLog = "Empty Field";
			return;
		}

		if (!Username.Contains ("@")) {
			cvsdebug.debugLog = "User do not exist";
			return;
		}
		if (Password != "123456") {
			cvsdebug.debugLog = "incorrect password";
			return;
		}

			

		List<bool> UnlockedC = new List<bool> (new bool[] {true,false,true});
		List<bool> UnlockedI = new List<bool> (new bool[] {true,false,true});
		Account.account.Setup (100, 10, 10000, 1000, 0, Username, 1, 1, UnlockedC, UnlockedI);
		print ("Login Successful");
		Application.LoadLevel ("MainMenu");
	}

	// Update is called once per frame
	void Update () {
		
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;


		
	}

	void AuthStateChanged(object sender, System.EventArgs eventArgs) {
		if (auth.CurrentUser != user) {
			bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
			if (!signedIn && user != null) {
				//Debug.LogError("Signed out " + user.UserId);
			}
			user = auth.CurrentUser;
			if (signedIn) {
				//Debug.LogError("Signed in " + user.UserId);
				//displayName = user.DisplayName ?? "";
				//emailAddress = user.Email ?? "";
				//photoUrl = user.PhotoUrl ?? "";
			}
		}
	}
}
	

