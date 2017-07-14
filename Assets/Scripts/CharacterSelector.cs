using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public int currentCharacter;
	public Transform charSelectionScroll;
	public ButtonPool charButtonPool;

	public Text charName;
	public Text healthText;
	public Text attackText;
	public Text speedText;
	public Text abilityText;
	public Text backGroundText;
	public Image curCharImage;
	public SpriteLibrary spriteDictionary;
	public CharLibrary charLibrary;

	private List<bool> unlockedCharacters;
	void Awake() {
		
	}

	void Start() {
		unlockedCharacters = Account.account.GetUnlockedCharacters ();
		AddButtons ();
		SetCharInfo (Account.account.GetCurrentCharacter ());
	}

	void AddButtons() {
		
		int i;
		int numChar = unlockedCharacters.Count;
		for (i = 0; i < numChar; ++i) {
			// Use pool to get gameobject(do not always destroy)
			GameObject newButton = charButtonPool.GetObject();
			newButton.transform.SetParent(charSelectionScroll);

			// Setup button with character id
			CharacterButton charButton = newButton.GetComponent<CharacterButton>();
			string spriteName = "char" + (i > 2 ? 0 : i).ToString() + "_main";
			Sprite s = spriteDictionary.charSpriteDic[spriteName];
			charButton.Setup(i, charLibrary.GetName(i), unlockedCharacters[i], this, s);
		}
	}

	public void SetCharInfo(int charId) {
		charName.text = charLibrary.GetName(charId);
		healthText.text = charLibrary.GetHealth(charId).ToString();
		attackText.text = charLibrary.GetAttack(charId).ToString();
		speedText.text = charLibrary.GetSpeed(charId).ToString();
		abilityText.text = "Ability: "+charLibrary.GetAbility(charId);
		backGroundText.text = charLibrary.GetStory(charId);

		string spriteName = "char" + (charId > 2 ? 0 : charId).ToString() + "_selection";
		curCharImage.overrideSprite = spriteDictionary.charSpriteDic[spriteName];
	}
}
