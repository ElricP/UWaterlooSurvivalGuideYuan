using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public int currentCharacter;
	public Transform charSelectionScroll;
	// public List<Button> characterButtons;
	public CharacterButtonPool charButtonPool;
	 
	private List<bool> unlockedCharacters;

	void Awake() {
			
	}

	void Start() {
		unlockedCharacters = Account.account.GetUnlockedCharacters ();
		AddButtons ();
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
}
