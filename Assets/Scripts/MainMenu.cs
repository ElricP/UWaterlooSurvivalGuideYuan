using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	//public Account curAccount;
	public Text goldText;
	public Text diamondText;

	// Use this for initialization
	void Start () {
		Account.account.SetGold (199999);
		setGoldText (Account.account.GetGold());
		setDiamondText (Account.account.GetDiamond());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setGoldText(int num) {
		goldText.text = num.ToString();
	}

	void setDiamondText(int num) {
		diamondText.text = num.ToString();
	}
}
