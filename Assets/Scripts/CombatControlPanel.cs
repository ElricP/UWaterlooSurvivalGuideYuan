using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatControlPanel : MonoBehaviour {

	public RewardPanel rewardPanel;
	public GameObject controlPanel;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		rewardPanel.gameObject.SetActive (false);
		controlPanel.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.currentHealth <= 0) {
			player.speed = 0;
			player.attackSpeed = 0;
			controlPanel.SetActive (false);
			rewardPanel.gameObject.SetActive (true);
			rewardPanel.Reward ();
		}
	}
}
