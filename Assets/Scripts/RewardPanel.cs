using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardPanel : MonoBehaviour {

	private int expReward = 100;
	private int goldReward = 100;
	private int diamondReward = 0;
	private int killedGoose = 0;

	public Text expText;
	public Text goldText;
	public Text diamondText;

	//public GameObject rewardPanel;

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
		expReward += killedGoose * 5;
		goldReward += killedGoose * 10;
		diamondReward += killedGoose / 10;
		SetAllTexts ();
		Account.account.ExpIncrease (expReward);
		Account.account.GoldChange (goldReward);
		Account.account.DiamondChange (diamondReward);
	}

	public void GooseKilled() {
		killedGoose++;
	}
}
