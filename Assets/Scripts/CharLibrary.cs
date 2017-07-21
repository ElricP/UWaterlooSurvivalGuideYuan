using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLibrary: MonoBehaviour {

	string[] nameDic = {
		"Thomas RealTime",
		"Hortons Developer",
		"Newton Physics"
	};

	string[] storyDic = {
		"A student of CS452 real time OS. While playing trains all day, he became " +
			"a multi-thread master and learned how to thread fork himself in order to survive on campus.",
		"A developer from Team Hortons. Got rekt in other shooting games and decided to make his/her " +
			"own one where he/she can be invincible even for seconds.",
		"A physics student in UW. Newton found that Acceleration =mass/force. During battles, " +
			"he periodically applies the great force to gain an immediate and powerful boost of speed, shadow step."
	};

	string[] abilityDic = {
		"Thread fork - clone himself to help himself but increase the DEADlock possibility ",
		"Coding is power - using Team Hortons power: become invincible for 5 seconds",
		"Shadow step - sudden dash to avoid apple falling from the trees",
	};

	int[] attackDic = {
		35,
		80,
		40
	};

	int[] healthDic = {
		200,
		300,
		100
	};

	int[] speedDic = {
		55,
		40,
		15
	};

	public string GetName(int id) {
		return nameDic [id];
	}

	public string GetStory(int id) {
		return storyDic [id];
	} 

	public string GetAbility(int id) {
		return abilityDic [id];
	}

	public int GetAttack(int id) {
		return attackDic [id];
	} 

	public int GetSpeed(int id) {
		return speedDic [id];
	} 

	public int GetHealth(int id) {
		return healthDic [id];
	} 
}

