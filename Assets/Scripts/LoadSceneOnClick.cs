using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
