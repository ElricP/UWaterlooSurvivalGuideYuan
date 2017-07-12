using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
	[SerializeField]
	private RewardPanel rewardPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Player").GetComponent<PlayerController>().currentHealth <= 0)
		{
			rewardPanel.gameObject.SetActive (true);
			rewardPanel.gameObject.GetComponent<RewardPanel> ().Reward ();
			GameObject.Find ("CombatControlPanel").SetActive (false);
			//GameObject.Find("Player").GetComponent<PlayerController>().Die();
		}
	}
}
