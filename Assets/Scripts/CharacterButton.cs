using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour {

	public Button buttonComponent;
	public Text nameLabel;
	public Transform scrollList;

	// Use this for initialization
	void Start () {
		buttonComponent.onClick.AddListener (OnClick);
	}

	// Update is called once per frame
	public void Setup (Sprite sprite, string name, bool unlocked) {
		nameLabel.text = name;
		buttonComponent.image.overrideSprite = sprite;

		// TODO: Edit size

	}

	public void OnClick() {
		nameLabel.text = "clicked";
	}
}