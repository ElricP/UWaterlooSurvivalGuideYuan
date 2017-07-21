using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour {

	//public PlayerController player;
	public GameObject[] Items;
	public float spawnTime = 25f;
	//public Transform spawnPoint;
	Transform[] healthKitPosition;

	// Use this for initialization
	void Start () {
		healthKitPosition = this.GetComponentsInChildren<Transform> ();
		InvokeRepeating ("ItemSpawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ItemSpawn() {

		/*if (player.currentHealth <= 0f) {
			return;
		}*/
		GameObject obj;
		int itemIndex = Random.Range (0, Items.Length-1);
		Vector3 spawnPos = itemIndex==1?randomHealthKitPosition():randomSpawnPosition ();
		if (itemIndex == 1) {
			GameObject[] kits = GameObject.FindGameObjectsWithTag ("HealthKit");
			if (kits.Length < 14) {
				obj = Instantiate (Items [itemIndex], spawnPos, Quaternion.identity); 
				obj.SetActive (true);
			}
		} else {
			obj = Instantiate (Items [itemIndex], spawnPos, Quaternion.identity); 
			obj.SetActive (true);
		}
	}

	Vector3 randomSpawnPosition() {
		int xCoord = Random.Range (-4000, 4000);
		int yCoord = Random.Range (-4000, 4000);
		int zCoord = -90;
		Vector3 pos = new Vector3 (xCoord, yCoord, zCoord);
		return pos;
	}

	Vector3 randomHealthKitPosition() {
		int positionIndex = Random.Range (0, healthKitPosition.Length-1);
		Vector2 posK = healthKitPosition [positionIndex].position;
		int zCoord = 0;
		Vector3 pos = new Vector3 (posK.x, posK.y, zCoord);
		return pos;
	}
}
