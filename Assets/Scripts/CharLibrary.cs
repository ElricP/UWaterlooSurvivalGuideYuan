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
		"A developer from Team Hortons. Almost invincible",
		"A physics student in UW."
	};

	string[] abilityDic = {
		"Thread fork - clone himself to help himself but increase the deadlock possibility ",
		"Developer Power - using Team Hortons power: become invincible for 5 seconds",
		"Shadow step - ",
	};

	int[] attackDic = {
		45,
		40,
		35
	};

	int[] healthDic = {
		100,
		90,
		50
	};

	int[] speedDic = {
		55,
		20,
		40
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

