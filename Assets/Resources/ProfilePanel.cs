using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour {

	public Text usernameText;
	public Text expText;
	public Text levelText;
	public Text inputText;
	public Image iconImage;
	public Transform iconSelectionScroll;
	public ButtonPool iconButtonPool;
	public GameObject selectionPanel;

	public SpriteLibrary spriteDictionary;

	// private List<bool> unlockedIcon;

	void Awake() {
		
	}
		
	// Use this for initialization
	void Start () {
		SetAllTexts ();
		SetIconImage ();
		AddButtons ();
	}

	void OnEnable() {
		SetAllTexts ();
		SetIconImage ();
	}
		
	public void SetAllTexts() {
		SetExpText (Account.account.GetExp());
		SetLevelText (Account.account.GetLevel ());
		SetUsernameText (Account.account.GetUsername ());
	}

	public void SetIconImage() {
		int i = Account.account.GetCurrentIcon ();
		string spriteName = "char" + (i > 2 ? 2 : i).ToString() + "_icon";
		iconImage.overrideSprite = spriteDictionary.charSpriteDic [spriteName];
	}

	public void CloseSelectionPanel() {
		selectionPanel.SetActive (false);
	}

	void SetUsernameText(string name) {
		usernameText.text = name;
	}

	void SetExpText(int exp) {
		expText.text = exp.ToString ();
	}

	void SetLevelText(int level) {
		levelText.text = level.ToString ();
	}

	public void UpdateAccountUsername() {
		Account.account.SetUsername (inputText.text);
		SetUsernameText (inputText.text);
	}

	void AddButtons() {

		int i;
		List<bool> unlockedIcons = Account.account.GetUnlockedIcons ();
		int numChar = unlockedIcons.Count;
		for (i = 0; i < numChar; ++i) {
			// Use pool to get gameobject(do not always destroy)
			GameObject newButton = iconButtonPool.GetObject();
			newButton.transform.SetParent(iconSelectionScroll);

			// Setup button with character id
			AccountIconButton iconButton = newButton.GetComponent<AccountIconButton>();
			string spriteName = "char" + (i > 2 ? 0 : i).ToString() + "_icon";
			Sprite s = spriteDictionary.charSpriteDic[spriteName];
			iconButton.Setup(i, unlockedIcons[i], this, s);
		}
	}
		
}
