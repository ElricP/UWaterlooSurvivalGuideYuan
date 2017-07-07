using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLibrary : MonoBehaviour {

	public Dictionary<string, Sprite> charSpriteDic;

	// Use this for initialization
	void Awake () {
		charSpriteDic = new Dictionary<string, Sprite>();
		Sprite[] sprites  = Resources.LoadAll<Sprite>("Characters/");
		foreach (Sprite s in sprites) {
			charSpriteDic [s.name] = s;
		}
	}
}
