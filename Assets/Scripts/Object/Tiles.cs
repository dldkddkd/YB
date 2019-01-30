using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {

    public bool able;

    private GameObject UI;
    public GameObject BUI1, BUI2, BUI3;

    void Start () {
        UI = GameObject.Find("UIs");
        BUI1 = GameObject.Find("BuildingUI");
        BUI2 = GameObject.Find("UpgradeUI");
        BUI3 = GameObject.Find("AbillityUI");

    }
	
	void Update ()
    {
        //BUI1 = GameObject.Find("BuildingUI");
        //BUI2 = GameObject.Find("UpgradeUI");
        //BUI3 = GameObject.Find("AbillityUI");

        //debug
        //if (able == false)
        //{
        //    GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        //}
    }

    private void OnMouseDown()
    {
        if (UI.GetComponent<UIManager>().dragging == false)
        {
            if (BUI1 != null)
            {
                if (BUI1.GetComponent<BuildingUIScr>().uion == false)
                {
                    UI.GetComponent<UIManager>().BuildSelect = false;
                }
            }
            if (BUI2 != null)
            {
                if (BUI2.GetComponent<BuildingUIScr>().uion == false)
                {
                    UI.GetComponent<UIManager>().Upgrading = false;
                }
            }
            if (BUI3 != null)
            {
                if (BUI3.GetComponent<BuildingUIScr>().uion == false)
                {
                    UI.GetComponent<UIManager>().ability = false;
                }
            }
        }
        else
        {
            if (GameObject.Find("Creator") != null && able == true)
            {
                GameObject.Find("Creator").GetComponent<BuildingCreate>().Create(transform.position.x, transform.position.y);
            }
        }
    }
}
