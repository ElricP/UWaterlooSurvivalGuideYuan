using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLibrary: MonoBehaviour {

	string[] nameDic = {
		"Thomas RealTime",
		"Newton Physics",
		"Hortons Developer"
	};

	string[] storyDic = {
		"A student of CS452 real time OS. While playing trains all day, he became " +
			"a multi-thread master and learned how to thread fork himself in order to survive on campus.",
		"",
		""
	};

	string[] abilityDic = {
		"Thread fork - clone himself to help himself but increase the deadlock possibility ",
		"",
		"Hortons Developer"
	};

	int[] attackDic = {
		45,
		10,
		35
	};

	int[] healthDic = {
		100,
		90,
		35
	};

	int[] speedDic = {
		55,
		20,
		35
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

