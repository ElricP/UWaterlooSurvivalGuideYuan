using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		
	}

	public void LoadByName(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
