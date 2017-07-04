using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour {

	public int expReward;
	public int goldReward;
	public int diamondReward;

	public Text expText;
	public Text goldText;
	public Text diamondText;
	public GameObject rewardPanel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetAllTexts() {
		setExpText (expReward);
		setGoldText (goldReward);
		setDiamondText (diamondReward);
	}

	private void setExpText(int num) {
		expText.text = "+" + num.ToString();
	}

	private void setGoldText(int num) {
		goldText.text = "+" + num.ToString();
	}

	private void setDiamondText(int num) {
		diamondText.text = "+" + num.ToString();
	}

	public void Reward() {
		SetAllTexts ();
		Account.account.SetExp (Account.account.GetExp () + expReward);
		Account.account.SetGold (Account.account.GetGold () + goldReward);
		Account.account.SetDiamond (Account.account.GetDiamond () + diamondReward);
	}

}
