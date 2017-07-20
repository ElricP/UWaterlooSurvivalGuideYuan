using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseFactory : MonoBehaviour {
	[SerializeField]
	private GameObject goose;
	public float spawnTime = 5f;
	private int killedGoose = 0;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("GooseSpawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GooseSpawn() {
		Vector3 spawnPos = randomSpawnPosition ();
		GameObject obj = Instantiate ( goose, spawnPos, Quaternion.identity); 
		obj.SetActive (true);
	}

	Vector3 randomSpawnPosition() {
		int xCoord = Random.Range (-4000, 4000);
		int yCoord = Random.Range (-4000, 4000);
		int zCoord = -90;
		Vector3 pos = new Vector3 (xCoord, yCoord, zCoord);
		return pos;
	}

	public void GooseKilled() {
		killedGoose++;
	}

	public int GetKilledGoose() {
		return killedGoose;
	}
}
