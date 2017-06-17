using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public Character currentCharacter;
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
			Sprite sprite  = Resources.Load<Sprite>("char1_main"); 

			// Use pool to get gameobject(do not always destroy)
			GameObject newButton = charButtonPool.GetObject();
			newButton.transform.SetParent(charSelectionScroll);

			CharacterButton sampleButton = newButton.GetComponent<CharacterButton>();
			sampleButton.Setup(sprite, "TestChar_"+i.ToString(), true);
		}
	}
}
