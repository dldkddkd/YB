using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {
	public GameObject title;
	public GameObject gameStartBtn;
	public GameObject settingsBtn;
	public GameObject gameExitBtn;
	public GameObject VolumeSlider;
	public GameObject VolumeText;
	public GameObject backBtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GoBack(){
		title.SetActive (true);
		gameStartBtn.SetActive (true);
		settingsBtn.SetActive (true);
		gameExitBtn.SetActive (true);
		VolumeSlider.SetActive (false);
		VolumeText.SetActive (false);
		backBtn.SetActive (false);
	}
}
