using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour {

	public Text usernameText;
	public Text expText;
	public Text levelText;
	public Text inputText;
	public Image iconImage;
	public SpriteLibrary spriteDictionary;

	// private List<bool> unlockedIcon;

	void Awake() {
		
	}
		
	// Use this for initialization
	void Start () {
		SetAllTexts ();
	}

	void OnEnable() {
		SetAllTexts ();
		int i = Account.account.GetCurrentIcon ();
		string spriteName = "char" + (i > 2 ? 2 : i).ToString() + "_icon";
		iconImage.overrideSprite = spriteDictionary.charSpriteDic [spriteName];
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
