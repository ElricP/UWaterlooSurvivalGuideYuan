using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class cvsDebug : MonoBehaviour {
	
	public Text debug;

	public string debugLog;


	// Use this for initialization
	void Start () {
		debugLog = "";
	}
	
	// Update is called once per frame
	void Update () {
		debug.text = debugLog;
	}
}
