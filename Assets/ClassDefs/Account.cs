using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account : MonoBehaviour {

	public int id;
	public string name;
	public Character currentCharacter;
	public List<Character> unlockedCharacters;
	public Icon icon;
	public List<Icon> unlockedIcons;
	public int exp;
	public int level;
	public int gold;
	public int diamond;

	// Use this for initialization
	void Start () {

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
}
