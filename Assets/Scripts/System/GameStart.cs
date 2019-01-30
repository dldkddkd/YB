using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
	public GameObject gameStartBtn;
	public GameObject settingsBtn;
	public GameObject gameExitBtn;
	public GameObject stageStartBtn;
	// Use this for initialization
	void Start () {
		GameObject.Find ("home").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("Main Camera").GetComponent<CameraScript> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Activate(){
        GameObject.Find("Title").SetActive(false);
        GameObject.Find("GameStartBtn").SetActive(false);
        GameObject.Find("SettingsBtn").SetActive(false);
        GameObject.Find("GameExitBtn").SetActive(false);
        GameObject.Find("Main Camera").GetComponent<CameraScript>().enabled = true;
        GameObject.Find("home").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("UIs").GetComponent<UIManager>().ingame = true;
        stageStartBtn.SetActive(true);
    }
}
