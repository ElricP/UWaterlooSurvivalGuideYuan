using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public int currentCharacter;
	public Transform charSelectionScroll;
	public CharacterButtonPool charButtonPool;

	public Text charName;
	public Text healthText;
	public Text attackText;
	public Text speedText;
	public Text abilityText;
	public Text backGroundText;
	public Image curCharImage;

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
			charButton.Setup(i, unlockedCharacters[i]);
		}
	}

	public void SetCharInfo(int charId) {
		charName.text = "UW Student " + charId.ToString ();
		healthText.text = (charId > 0 ? 35 : 25).ToString();
		attackText.text = (charId > 0 ? 20 : 40).ToString();
		speedText.text = (charId > 0 ? 50 : 40).ToString();
		//abilityText.text = (charId > 0 ? 50 : 40).ToString();
		//backGroundText.text = (charId > 0 ? 50 : 40).ToString();
		Sprite sprite  = Resources.Load<Sprite>("char"+charId.ToString()+"_main"); 
		curCharImage.overrideSprite = sprite;
	}
}
