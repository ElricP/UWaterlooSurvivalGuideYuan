using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
	public Character currentCharacter;
	int numChar = 6;
	public Transform charSelectionScroll;
	public List<Button> characterButtons;
	public CharacterButtonPool charButtonPool;
	void Awake() {
			
	}

	void Start() {
		AddButtons ();
	}

	void AddButtons() {
		int i;
		for (i = 0; i < numChar; ++i) {
			// Vector3 position = new Vector3(0, 0, 0);
			// Vector2 size = new Vector2(64, 66);
			// Sprite sprite  = Resources.Load<Sprite>("coin"); 

			// Use pool to get gameobject(do not destroy)
			GameObject newButton = charButtonPool.GetObject();
			newButton.transform.SetParent(charSelectionScroll);

			CharacterButton sampleButton = newButton.GetComponent<CharacterButton>();
			//sampleButton.transform.positon = new Vector3 (100, i * 80, 0);
			sampleButton.Setup();
		}
	}
	public GameObject CreateButton(Transform panel ,Vector3 position, Vector2 size,  Sprite sprite)
	{
		GameObject button = new GameObject();
		button.transform.parent = panel;
		button.AddComponent<RectTransform>();
		button.AddComponent<Button>();
		button.transform.position = position;
		//button.RectTransform.width = 100;
		//button.RectTransform.height= 28;
		//button.Text.text = "My Button";
		//button.RectTransform.posX= 0;
		//button.RectTransform.posY= 0;
		//button.GetComponent<RectTransform>();
		// button.GetComponent<Button>().onClick.AddListener(method);

		Image image = button.AddComponent<Image>();
		image.sprite = sprite;

		//UnityEngine.UI.Button button = go.AddComponent<UnityEngine.UI.Button>();
		// button.transform.SetParent(panel, false);

		//image.rectTransform.sizeDelta = size;
		return button;
	}

}
