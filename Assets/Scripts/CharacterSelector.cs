using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public int currentCharacter;
	int numChar = 7;
	public Transform charSelectionScroll;
	// public List<Button> characterButtons;
	public CharacterButtonPool charButtonPool;

	void Awake() {
			
	}

	void Start() {
		AddButtons ();
	}

	void AddButtons() {
		int i;
		for (i = 0; i < numChar; ++i) {
			// Use pool to get gameobject(do not always destroy)
			GameObject newButton = charButtonPool.GetObject();
			newButton.transform.SetParent(charSelectionScroll);

			// Setup button with character id
			CharacterButton sampleButton = newButton.GetComponent<CharacterButton>();
			sampleButton.Setup(i);
		}
	}
}
