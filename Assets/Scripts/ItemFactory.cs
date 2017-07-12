using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {

	//public PlayerController player;
	public GameObject[] Items;
	public float spawnTime = 20f;
	//public Transform spawnPoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("ItemSpawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ItemSpawn() {

		/*if (player.currentHealth <= 0f) {
			return;
		}*/
		int itemIndex = Random.Range (0, Items.Length-1);
		Vector3 spawnPos = randomSpawnPosition ();
		GameObject obj = Instantiate (Items [itemIndex], spawnPos, Quaternion.identity); 
		obj.SetActive (true);
	}

	Vector3 randomSpawnPosition() {
		int xCoord = Random.Range (-4000, 4000);
		int yCoord = Random.Range (-4000, 4000);
		int zCoord = -90;
		Vector3 pos = new Vector3 (xCoord, yCoord, zCoord);
		return pos;
	}
}
