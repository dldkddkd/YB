using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public bool BuildSelect;
    public bool dragging;

    public Image Building;

    public GameObject ct;

    void Start () {
        BuildSelect = false;
        dragging = false;

        Building.gameObject.SetActive(false);

        ct = GameObject.Find("Creator");
        ct.gameObject.SetActive(false);
    }
	
	void Update () {
        if (BuildSelect == true)
        {
            Building.gameObject.SetActive(true);
        }
        else
        {
            Building.gameObject.SetActive(false);
        }
	}

    public void BSelect(int bnum)
    {
        ct.gameObject.SetActive(true);
        ct.GetComponent<BuildingCreate>().On(bnum);
        dragging = true;
        BuildSelect = false;
    }
}
