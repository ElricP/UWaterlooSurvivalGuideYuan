using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour {

	public Text usernameText;
	public Text expText;
	public Text levelText;
	public Text inputText;
	private TouchScreenKeyboard keyboard;

	// Use this for initialization
	void Start () {
		SetAllTexts ();
	}

	public void SetAllTexts() {
		SetExpText (Account.account.GetExp());
		SetLevelText (Account.account.GetLevel ());
		SetUsernameText (Account.account.GetUsername ());
	}

	public void SetUsernameText(string name) {
		usernameText.text = name;
	}

	public void SetExpText(int exp) {
		expText.text = exp.ToString ();
	}

	public void SetLevelText(int level) {
		levelText.text = level.ToString ();
	}

	public void UpdateAccountUsername() {
		Account.account.SetUsername (inputText.text);
		SetUsernameText (inputText.text);
	}
}
