using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
	[SerializeField]
	private RewardPanel rewardPanel;
	[SerializeField]
	private GameObject controlPanel;
	private bool rewarded = false;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(!rewarded && GameObject.Find("Player").GetComponent<PlayerController>().currentHealth <= 0)
		{
			rewarded = true;
			rewardPanel.gameObject.SetActive (true);
			rewardPanel.gameObject.GetComponent<RewardPanel> ().Reward ();
			//controlPanel.gameObject.GetComponent.SetActive (false);
			//GameObject.Find ("CombatControlPanel").SetActive (false);
			//GameObject.Find("Player").GetComponent<PlayerController>().Die();
		}
	}
}
