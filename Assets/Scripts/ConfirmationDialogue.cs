using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationDialogue : MonoBehaviour {

	public Button buyGold;
	public Button buyDiamond;
	public Image itemImage;
	public Text diamondPriceText;
	public Text goldPriceText;
	int goldPrice;
	int diamondPrice;

	void Start() {
		buyGold.onClick.AddListener (BuyWithGold);
		buyDiamond.onClick.AddListener (BuyWithDiamond);
	}

	void OnEnable () {
		int gold = Account.account.GetGold ();
		int diamond = Account.account.GetDiamond ();
		buyGold.interactable = (gold >= goldPrice);
		buyDiamond.interactable = (diamond >= diamondPrice);
	}
	
	// Update is called once per frame
	public void SetUp(int gp, int dp, Sprite s) {
		goldPrice = gp;
		diamondPrice = dp;
		diamondPriceText.text = diamondPrice.ToString();
		goldPriceText.text = goldPrice.ToString ();
		itemImage.overrideSprite = s;
	}

	public void BuyWithGold() {
		int gold = Account.account.GetGold ();
		if (gold >= goldPrice) {
			Account.account.SetGold (gold-goldPrice);
		}
	}

	public void BuyWithDiamond() {
		int diamond = Account.account.GetDiamond ();
		if (diamond >= diamondPrice) {
			Account.account.SetDiamond (diamond-diamondPrice);
		}
	}
}
