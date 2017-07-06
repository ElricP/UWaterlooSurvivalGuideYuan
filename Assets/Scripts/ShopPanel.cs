using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour {

	public Text goldText;
	public Text diamondText;
	public Transform commodityScroll;
	public ButtonPool buttonPool;
	public GameObject confirmationDialogue;

	private List<bool> unlockedCharacters;
	private List<CommodityButton> buttons;
	private Dictionary<string, Sprite> commoditySpriteDic;
	void Awake() {
		makeCommoditySpriteDictionay ();
	}

	private void makeCommoditySpriteDictionay() {
		commoditySpriteDic = new Dictionary<string, Sprite>();
		Sprite[] sprites  = Resources.LoadAll<Sprite>("Characters/");
		foreach (Sprite s in sprites) {
			commoditySpriteDic [s.name] = s;
		}
	}

	void Start () {
		unlockedCharacters = Account.account.GetUnlockedCharacters ();
		SetAllTexts ();
		AddButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		SetAllTexts ();
	}

	public void SetAllTexts() {
		setGoldText (Account.account.GetGold());
		setDiamondText (Account.account.GetDiamond());
	}

	private void setGoldText(int num) {
		goldText.text = num.ToString();
	}

	private void setDiamondText(int num) {
		diamondText.text = num.ToString();
	}

	void AddButtons() {

		int i;
		int numChar = unlockedCharacters.Count;
		for (i = 0; i < numChar; ++i) {
			if (unlockedCharacters [i]) {
				continue;
			}

			// Use pool to get gameobject(do not always destroy)
			GameObject newButton = buttonPool.GetObject();
			newButton.transform.SetParent(commodityScroll);

			// Setup button with character id
			CommodityButton commodityButton = newButton.GetComponent<CommodityButton>();
			string spriteName = "char" + (i > 2 ? 2 : i).ToString() + "_main";
			Sprite s = commoditySpriteDic[spriteName];

			commodityButton.Setup(this, confirmationDialogue, i, 1000, 1000 , s);
			//buttons.Add (commodityButton);
		}
	}

}
