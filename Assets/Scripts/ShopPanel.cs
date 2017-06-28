using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour {

	public Text goldText;
	public Text diamondText;

	void OnEnable () {
		SetAllTexts ();
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void Buy() {
	}
}
