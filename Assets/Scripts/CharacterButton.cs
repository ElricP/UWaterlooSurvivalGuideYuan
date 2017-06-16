using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour {

	Button button;
	public Text nameLabel;
	//public Sprite iconImage;
	public Transform transform;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public void Setup () {
		nameLabel.text = "test";
		//transform.position = new Vector3(0, 0, 0);
		//RectTransform.height= 28;
		//button.RectTransform.posX= 0;
		//button.RectTransform.posY= 0;
	}
}