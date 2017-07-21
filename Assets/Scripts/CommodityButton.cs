using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommodityButton : MonoBehaviour {

	public Button buttonComponent;
	public Text diamondPriceText;
	public Text goldPriceText;
	public Image iconImage;
	public GameObject confirmDialogue;

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

	void LateUpdate() {
		List<bool> unlockedChars = Account.account.GetUnlockedCharacters ();
		buttonComponent.interactable = !unlockedChars[itemId];
	}

	public void Setup (ShopPanel shopPanel, GameObject dialogue, int itemId, int diamondPrice, int goldPrice, Sprite buttonSprite, bool unlocked) {
		this.itemId = itemId;
		shop = shopPanel;
		confirmDialogue = dialogue;
		this.goldPrice = goldPrice;
		this.diamondPrice = diamondPrice;
		diamondPriceText.text = diamondPrice.ToString();
		goldPriceText.text = goldPrice.ToString ();
		iconImage.sprite = buttonSprite;
		buttonComponent.interactable = !unlocked;

		// TODO: Edit size

	}

	public void OnClick() {
		ConfirmationDialogue cd = confirmDialogue.GetComponent<ConfirmationDialogue> ();
		cd.SetUp (itemId, goldPrice, diamondPrice, iconImage.sprite);
		confirmDialogue.SetActive(true);
	}
}
