using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Image lockImage;
	public Transform scrollList;

	private int charInd;
	private CharacterSelector selector;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (OnClick);
	}

	void Update() {
		// Use this to unable locked char selection
		// TODO: find a more efficient way
		OnEnable ();	
	}

	// Update is called once per frame
	public void Setup (int charId, bool unlocked, CharacterSelector cur, Sprite buttonSprite) {
		nameLabel.text = "TestChar_"+charId.ToString();
		buttonComponent.image.overrideSprite = buttonSprite;
		buttonComponent.interactable = unlocked;

		if (unlocked) {
			lockImage.enabled = false;
		}
		if (Account.account.GetCurrentCharacter () == charId) {
			buttonComponent.Select ();
		}
		charInd = charId;
		selector = cur;
		// TODO: Edit size

	}

	public void OnClick() {
		Account.account.SetCurrentCharacter (charInd);
		selector.SetCharInfo (charInd);
	}

	void OnEnable() {
		if (Account.account.GetCurrentCharacter () == charInd) {
			buttonComponent.Select ();
		}
	}
}