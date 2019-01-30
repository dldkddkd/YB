using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUIScr : MonoBehaviour {

    public bool uion;

	void Start () {
        uion = false;
	}

    private void OnMouseEnter()
    {
        uion = true;
    }
    private void OnMouseExit()
    {
        uion = false;
    }

    public void MouseOn()
    {
        uion = true;
    }
    public void MouseOff()
    {
        uion = false;
    }
}
