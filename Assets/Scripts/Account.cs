﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Account : MonoBehaviour {

	public static Account account;
	private int id;
	private string username;
	private int currentCharacter;
	private List<bool> unlockedCharacters;
	private int currentIcon;
	private List<bool> unlockedIcons;
	private int exp;
	private int level;
	private int gold;
	private int diamond;
	private float musicVolume;
	private float effectVolume;

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

	}

	// Update is called once per frame
	void Update () {

	}

	// initialize account info
	public void Setup(int initExp, int initLevel, int initGold, int initDiamond, int initId, string initUsername, int initCurrentCharacter, 
		              int initCurrentIcon, List<bool> initUnlockedCharacters, List<bool> initUnlockedIcons ) {
		exp = initExp;
		level = initLevel;
		gold = initGold;
		diamond = initDiamond;
		id = initId;
		username = initUsername;
		currentCharacter = initCurrentCharacter;
		currentIcon = initCurrentIcon;
		unlockedCharacters = initUnlockedCharacters;
		unlockedIcons = initUnlockedIcons;
	}

	// ID
	public void SetId(int idToBeAss) {
		id = idToBeAss;
	}
		
	// Name
	public string GetUsername () {
		return username;
	}
	public void SetUsername(string newName) {
		username = newName;
	}

	// Character
	public int GetCurrentCharacter () {
		return currentCharacter;
	}
	public void SetCurrentCharacter(int charId) {
		currentCharacter = charId;
	}
	public void SetUnlockedCharacters (List<bool> CharacterUnlockArray) {
		unlockedCharacters = CharacterUnlockArray;
	}
	public List<bool> GetUnlockedCharacters () {
		return unlockedCharacters;
	}
	public void UnlockCharacter(int CharId) {
		unlockedCharacters [CharId] = true;
	}


	// Icon
	public int GetCurrentIcon() {
		return currentIcon;
	}
	public void SetCurrentIcon(int iconId) {
		currentIcon = iconId;
	}
	public void SetUnlockedIcons(List<bool> IconUnlockArray) {
		unlockedIcons = IconUnlockArray;
	}
	public List<bool> GetUnlockedIcons () {
		return unlockedIcons;
	}
	public void UnlockIcon(int iconId) {
		unlockedIcons [iconId] = true;
	}

	//exp and level

	public void SetExp(int newExp) {
		exp = newExp;
	}
	public int GetExp() {
		return exp;
	}
	public void SetLevel(int newLevel) {
		level = newLevel;
	}
	public int GetLevel() {
		return level;
	}
	public void ExpIncrease(int GainedExp) {
		level += (exp + GainedExp) / 200;
		exp = (exp + GainedExp) % 200;
	}

	// Gold
	public int GetGold() {
		return gold;
	}

	public void SetGold(int newGold) {
		gold = newGold;
	}
	public void GoldChange(int changeGold) {
		gold += changeGold;
	}

	// Diamond
	public void SetDiamond(int newDiamond) {
		diamond = newDiamond;
	}

	public int GetDiamond() {
		return diamond;
	}
	public void DiamondChange(int changeDiamond) {
		diamond += changeDiamond;
	}		

	public float GetMusicVolume() {
		return musicVolume;
	}

	public float GetEffectVolume() {
		return effectVolume;
	}

	public void SetMusicVolume(float v) {
		musicVolume = v;
	}

	public void SetEffectVolume(float v) {
		effectVolume = v;
	}
}
