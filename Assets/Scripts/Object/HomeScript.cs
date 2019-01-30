using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour {

    private int hp;

	void Start () {
        hp = 5000;
	}
	

	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject.Find("UIs").GetComponent<UIManager>().BuildSelect = true;
        GameObject.Find("UIs").GetComponent<UIManager>().Upgrading = false;
        GameObject.Find("UIs").GetComponent<UIManager>().ability = false;
    }
}
