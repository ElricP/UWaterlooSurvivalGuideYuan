using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommodityButton : MonoBehaviour {

	public Button buttonComponent;
	public Text diamondPriceText;
	public Text goldPriceText;
	public Image iconImage;

	private ShopPanel shop;
	private int itemId;
	private int diamondPrice;
	private int goldPrice;


	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Setup (ShopPanel shopPanel, int itemId, int diamondPrice, int goldPrice, Sprite buttonSprite) {
		this.itemId = itemId;
		shop = shopPanel;
		this.goldPrice = goldPrice;
		this.diamondPrice = this.diamondPrice;
		diamondPriceText.text = diamondPrice.ToString();
		goldPriceText.text = goldPrice.ToString ();
		iconImage.overrideSprite = buttonSprite;
		buttonComponent.interactable = true;

		// TODO: Edit size

	}

	public void OnClick() {
		//Account.account.
		buy();
	}

	void buy() {
		int gold = Account.account.GetGold ();
		if (gold >= goldPrice) {
			Account.account.SetGold (gold-goldPrice);
			shop.SetAllTexts();
		}
	}
}
