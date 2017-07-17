using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {

	public Slider musicSlider;
	public Slider soundSlider;
	private int BGMVolume;
	private int SFXVolume;

	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		musicSlider.value = Account.account.GetMusicVolume ();
	}

	public void ChangeMusic() {
		float v = musicSlider.value;
		Account.account.SetMusicVolume (v);
	}

	public void ChangeSoundEffect() {
		float v = soundSlider.value;
		Account.account.SetEffectVolume (v);
	}
}
