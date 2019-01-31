using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public bool ingame;
    public bool BuildSelect;
    public bool dragging;
    public bool Upgrading;
    public bool slideron;
    public bool ability;
    public bool ab1, ab2;
    public bool gameover;
    public int stage;

    public Image Building;
    public Image Upgrade;
    public Image AbilityPopup, Ab1passive, Ab2passive;
    private GameObject uptmp;
    private int uptype, price, sel;

    public GameObject Sliders;
    public GameObject StageUI;
    public GameObject GOUI;

    public GameObject ct;
    private GameObject ps;
    
    void Start ()
    {
        Screen.SetResolution(1280, 960, false);
        ingame = false;
        BuildSelect = false;
        dragging = false;
        slideron = true;
        ability = false;
        ab1 = false;
        ab2 = false;
        gameover = false;
        stage = 1;  //0=스테이지 넘버 출력, 1=대기, 2=게임시작 출력 3=게임중

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
                Upgrading = false;
                ability = false;
            }
            else
            {
                Building.gameObject.SetActive(false);
            }
            if (Upgrading == true)
            {
                BuildSelect = false;
                Upgrade.gameObject.SetActive(true);
                ability = false;
            }
            else
            {
                Upgrade.gameObject.SetActive(false);
            }
            if (ability == true)
            {
                BuildSelect = false;
                Upgrading = false;
                AbilityPopup.gameObject.SetActive(true);
            }
            else
            {
                AbilityPopup.gameObject.SetActive(false);
            }


            if (slideron == true)
            {
                Sliders.gameObject.SetActive(true);
            }
            else
            {
                Sliders.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                slideron = !slideron;
            }

            if (stage == 0 || stage == 2)
            {
                StageUI.transform.GetChild(0).gameObject.SetActive(false);
                StageUI.transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (stage == 1)
            {
                StageUI.transform.GetChild(0).gameObject.SetActive(true);
                StageUI.transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (stage == 3)
            {
                StageUI.transform.GetChild(0).gameObject.SetActive(false);
                StageUI.transform.GetChild(1).gameObject.SetActive(false);
            }

            if (ab1 == true)
            {
                Ab1passive.gameObject.SetActive(true);
            }
            else
            {
                Ab1passive.gameObject.SetActive(false);
            }
            if (ab2 == true)
            {
                Ab2passive.gameObject.SetActive(true);
            }
            else
            {
                Ab2passive.gameObject.SetActive(false);
            }

        }
        else
        {
            Building.gameObject.SetActive(false);
            Upgrade.gameObject.SetActive(false);
            Sliders.gameObject.SetActive(false);
            AbilityPopup.gameObject.SetActive(false);
        }

        if (gameover == true)
        {
            GOUI.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            GOUI.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BSelect(int bnum)
    {
        if (ps.transform.GetChild(0) != null)
        {
            ct.gameObject.SetActive(true);
            ct.GetComponent<BuildingCreate>().On(bnum);
            dragging = true;
            Building.GetComponent<BuildingUIScr>().uion = false;
            BuildSelect = false;
        }
    }

    public void UpgradeUI(GameObject obj, int type, int level, int cost1, int cost2, int hpspec, int hpup, int otherspec, int otherup)
    {
        uptmp = obj;
        uptype = type;
        price = cost1;
        sel = cost2;
        Upgrading = true;
        BuildSelect = false;
        ability = false;
        if (level < 3)
        {
            Upgrade.transform.GetChild(0).gameObject.SetActive(true);
            Upgrade.transform.GetChild(2).gameObject.SetActive(true);
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
        else
        {
            Upgrade.transform.GetChild(0).gameObject.SetActive(false);
            Upgrade.transform.GetChild(2).gameObject.SetActive(false);
            Upgrade.transform.GetChild(3).GetComponent<Text>().text = "Cost: " + cost2.ToString() + "p";
            if (type == 1)
            {
                Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString();
            }
            else if (type == 2)
            {
                Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString() + "\nAD: " + otherspec.ToString();
            }
            else if (type == 3)
            {
                Upgrade.transform.GetChild(4).GetComponent<Text>().text = "HP: " + hpspec.ToString() + "\nBonus: " + otherspec.ToString();
            }
        }
    }
    public void SelectUpgrade()
    {
        if (ps.GetComponent<PlayerSystem>().money >= price)
        {
            ps.GetComponent<PlayerSystem>().money -= price;
            Upgrade.GetComponent<BuildingUIScr>().uion = false;
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
        Upgrade.GetComponent<BuildingUIScr>().uion = false;
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
    
    public void StageEnd(int num)
    {
        //stageScr->End
        stage = 0;
        StageUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Stage " + num;
        ab1 = false;
        ab2 = false;
        ps.GetComponent<PlayerSystem>().ab1 = false;
        ps.GetComponent<PlayerSystem>().ab2 = false;
        StartCoroutine(StageTxt());
    }
    IEnumerator StageTxt()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            stage = 1;
            yield break;
        }
    }
    public void StageStart()
    {
        //Button
        stage = 2;
        StageUI.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Start!";
        StartCoroutine(StartTxt());
        GameObject.Find("StageManager").GetComponent<Stage>().StageStart();
    }
    IEnumerator StartTxt()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            stage = 3;
            yield break;
        }
    }

    public void GameOverBtn()
    {
        gameover = false;
        SceneManager.LoadScene("MainScene");
    }
}
