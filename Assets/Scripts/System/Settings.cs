using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {
	public GameObject title;
	public GameObject VolumeSlider;
	public GameObject VolumeText;
	public GameObject backBtn;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Activate(){		
		GameObject.Find ("Title").SetActive (false);
		GameObject.Find ("GameStartBtn").SetActive (false);
		GameObject.Find ("SettingsBtn").SetActive (false);
		GameObject.Find ("GameExitBtn").SetActive (false);
		VolumeSlider.SetActive (true);
		VolumeText.SetActive (true);
		backBtn.SetActive (true);
	}

}
