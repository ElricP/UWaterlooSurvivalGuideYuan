using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Image lockImage;
	public Transform scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (OnClick);
	}

	// Update is called once per frame
	public void Setup (int charId, bool unlocked) {
		Sprite sprite  = Resources.Load<Sprite>("char1_main"); 
		nameLabel.text = "TestChar_"+charId.ToString();
		buttonComponent.image.overrideSprite = sprite;
		buttonComponent.interactable = unlocked;

		if (unlocked) {
			lockImage.enabled = false;
		}
		// TODO: Edit size

	}

	public void OnClick() {
		nameLabel.text = "clicked";
	}
}