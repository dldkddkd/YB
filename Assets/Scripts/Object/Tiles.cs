using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {

    public bool able;

    private GameObject UI;
    private GameObject BUI;

    void Start () {
        UI = GameObject.Find("UIs");
        BUI = GameObject.Find("BuildingUI");

    }
	
	void Update () {


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
            if (BUI != null)
            {
                if (BUI.GetComponent<BuildingUIScr>().uion == false)
                {
                    UI.GetComponent<UIManager>().BuildSelect = false;
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
