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

	private List<bool> unlockedCharacters;
	private Dictionary<string, Sprite> charSpriteDic;
	void Awake() {
		makeCharSpriteDictionay ();
	}

	void Start() {
		unlockedCharacters = Account.account.GetUnlockedCharacters ();
		AddButtons ();
		SetCharInfo (Account.account.GetCurrentCharacter ());
	}

	void makeCharSpriteDictionay() {
		charSpriteDic = new Dictionary<string, Sprite>();
		Sprite[] sprites  = Resources.LoadAll<Sprite>("Characters/");
		foreach (Sprite s in sprites) {
			charSpriteDic [s.name] = s;
		}
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
			Sprite s = charSpriteDic[spriteName];
			charButton.Setup(i, unlockedCharacters[i], this, s);
		}
	}

	public void SetCharInfo(int charId) {
		charName.text = "UW Student " + charId.ToString ();
		healthText.text = (charId > 1 ? 35 : 25+charId).ToString();
		attackText.text = (charId > 1 ? 20 : 40+charId).ToString();
		speedText.text = (charId > 1 ? 50 : 40+charId).ToString();
		//abilityText.text = (charId > 0 ? 50 : 40).ToString();
		//backGroundText.text = (charId > 0 ? 50 : 40).ToString();

		string spriteName = "char" + (charId > 2 ? 0 : charId).ToString() + "_selection";
		curCharImage.overrideSprite = charSpriteDic[spriteName];
	}
}
