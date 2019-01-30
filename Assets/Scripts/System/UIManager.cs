using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public bool ingame;
    public bool BuildSelect;
    public bool dragging;
    public bool Upgrading;
    public bool slideron;

    public Image Building;
    public Image Upgrade;
    private GameObject uptmp;
    private int uptype, price, sel;

    public GameObject Sliders;

    public GameObject ct;
    private GameObject ps;

    void Start () {
        ingame = false;
        BuildSelect = false;
        dragging = false;
        slideron = true;

        Building.gameObject.SetActive(false);
        Upgrade.gameObject.SetActive(false);
        Sliders.gameObject.SetActive(false);

        ct = GameObject.Find("Creator");
        ct.gameObject.SetActive(false);

        ps = GameObject.Find("Player");
    }
	
	void Update () {
        if (ingame == true)
        {
            if (BuildSelect == true)
            {
                Building.gameObject.SetActive(true);
            }
            else
            {
                Building.gameObject.SetActive(false);
            }
            if (Upgrading == true)
            {
                Upgrade.gameObject.SetActive(true);
            }
            else
            {
                Upgrade.gameObject.SetActive(false);
            }
            if (slideron == true)
            {
                Sliders.gameObject.SetActive(true);
            }
            else
            {
                Sliders.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                slideron = !slideron;
            }
        }
    }

    public void BSelect(int bnum)
    {
        ct.gameObject.SetActive(true);
        ct.GetComponent<BuildingCreate>().On(bnum);
        dragging = true;
        BuildSelect = false;
    }

    public void UpgradeUI(GameObject obj, int type, int cost1, int cost2, int hpspec, int hpup, int otherspec, int otherup)
    {
        uptmp = obj;
        uptype = type;
        price = cost1;
        sel = cost2;
        Upgrading = true;
        Upgrade.transform.GetChild(2).GetComponent<Text>().text = "Cost: " + cost1.ToString() + "p";
        Upgrade.transform.GetChild(3).GetComponent<Text>().text = "Cost: " + cost2.ToString() + "p";
        if (type == 1)
        {
            Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString() + "(+" + hpup.ToString() + ")";
        }
        else if (type == 2)
        {
            Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString() + "(+" + hpup.ToString() + ")\nAD: " + otherspec.ToString() + "(+" + otherup.ToString() + ")";
        }
        else if (type == 3)
        {
            Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString() + "(+" + hpup.ToString() + ")\nBonus: " + otherspec.ToString() + "(+" + otherup.ToString() + ")";
        }
    }
    public void SelectUpgrade()
    {
        if (ps.GetComponent<PlayerSystem>().money >= price)
        {
            ps.GetComponent<PlayerSystem>().money -= price;
            Upgrading = false;
            if (uptype == 1)
            {
                uptmp.GetComponent<Wallupgrade>().Upgrade();
            }
            else if (uptype == 2)
            {
                uptmp.GetComponent<Towerupgrade>().Upgrade();
            }
            else if (uptype == 3)
            {
                uptmp.GetComponent<Fieldupgrade>().Upgrade();
            }
        }
    }
    public void SelectDelete()
    {
        Upgrading = false;
        if (uptype == 1)
        {
            uptmp.GetComponent<Wallupgrade>().Delete();
        }
        else if (uptype == 2)
        {
            uptmp.GetComponent<Towerupgrade>().Delete();
        }
        else if (uptype == 3)
        {
            uptmp.GetComponent<Fieldupgrade>().Delete();
        }
    }
}
