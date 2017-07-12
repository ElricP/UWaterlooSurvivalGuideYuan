using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	//public Account curAccount;
	public Text goldText;
	public Text diamondText;
	public Image charImage;
	public Image profileImage;
	public SpriteLibrary spriteDictionary;

	// Use this for initialization
	void Start () {
		SetAllTexts ();
		int i = Account.account.GetCurrentIcon ();
		string spriteName = "char" + (i > 2 ? 2 : i).ToString() + "_icon";
		profileImage.overrideSprite = spriteDictionary.charSpriteDic [spriteName];
	}

	void LateUpdate() {
		SetAllTexts ();
		int i = Account.account.GetCurrentIcon ();
		string spriteName = "char" + (i > 2 ? 2 : i).ToString() + "_icon";
		profileImage.overrideSprite = spriteDictionary.charSpriteDic [spriteName];
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetAllTexts() {
		setGoldText (Account.account.GetGold());
		setDiamondText (Account.account.GetDiamond());
	}

	private void setGoldText(int num) {
		goldText.text = num.ToString();
	}

	private void setDiamondText(int num) {
		diamondText.text = num.ToString();
	}
}
