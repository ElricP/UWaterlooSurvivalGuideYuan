using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountIconButton : MonoBehaviour {

	public Button buttonComponent;
	public Image lockImage;

	private int iconInd;
	private ProfilePanel panel;

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
	public void Setup (int iconInd, bool unlocked, ProfilePanel panel, Sprite buttonSprite) {
		buttonComponent.image.overrideSprite = buttonSprite;
		buttonComponent.interactable = unlocked;

		if (unlocked) {
			lockImage.enabled = false;
		}
		if (Account.account.GetCurrentIcon () == iconInd) {
			buttonComponent.Select ();
		}
		this.iconInd = iconInd;
		this.panel = panel;
		// TODO: Edit size

	}

	public void OnClick() {
		Account.account.SetCurrentIcon (iconInd);
		panel.SetIconImage ();
		panel.CloseSelectionPanel ();
	}

	void OnEnable() {
		if (Account.account.GetCurrentIcon () == iconInd) {
			buttonComponent.Select ();
		}
	}
}