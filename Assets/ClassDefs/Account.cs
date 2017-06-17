﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour {

	public static Account account;
	public int id;
	public string name;
	public int currentCharacter;
	public List<bool> unlockedCharacters;
	public int currentIcon;
	public List<bool> unlockedIcons;
	public int exp;
	public int level;
	public int gold;
	public int diamond;

	public Text goldText;
	public Text diamondText;

	// Ensure only one account exists and persist over scenes
	void Awake() {
		if (account == null) {
			DontDestroyOnLoad (gameObject);
			account = this;
		} else if (account != this) {
			Destroy (gameObject);
		}	
	}

	// Use this for initialization
	void Start () {
		SetGoldText (0);
		SetDiamondText (0);
	}

	// Update is called once per frame
	void Update () {

	}

	void Rename(string newName) {
		name = newName;
	}

	void SelectChar(int charId) {
		// TODO
	}

	void SelectIcon(int iconId) {
		// TODO
	}

	void Levelup() {
		// TODO
	}

	void SetExp(int newExp) {
		exp = newExp;
	}

	void SetGold(int newGold) {
		gold = newGold;
	}

	void SetDiamond(int newDiamond) {
		diamond = newDiamond;
	}

	void UnlockChar(int charId) {
		// TODO
	}

	void UnlockIcon(int iconId) {
		// TODO
	}

	void SetGoldText(int newGold) {
		goldText.text = newGold.ToString();
	}

	void SetDiamondText(int newDiamond) {
		diamondText.text = newDiamond.ToString();
	}
}
