using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldupgrade : MonoBehaviour {
    public int xul, xdl, yul, ydl;
    private int level;
    public int fhp, maxfhp, bonus;
    public bool click;
    private int upcost, selcost;
    public Sprite lv1spr, lv2spr, lv3spr;

    private UIManager UIM;
    private GameObject BUI2;

    void Start()
    {
        GetComponent<WallScr>().xul = xul;
        GetComponent<WallScr>().xdl = xdl;
        GetComponent<WallScr>().yul = yul;
        GetComponent<WallScr>().ydl = ydl;

        level = 1;
        fhp = 100;
        maxfhp = 100;
        bonus = 100;
        click = false;
        upcost = 125;
        selcost = 30;
        GetComponent<SpriteRenderer>().sprite = lv1spr;

        UIM = GameObject.Find("UIs").GetComponent<UIManager>();
        BUI2 = UIM.Upgrade.gameObject;
    }

    void Update()
    {

    }

    public void Upgrade()
    {
        if (level < 3)
        {
            level += 1;
            if (level == 2)
            {
                GetComponent<SpriteRenderer>().sprite = lv2spr;
                fhp = 200;
                maxfhp = 200;
                bonus += 200;
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lv3spr;
                fhp = 300;
                maxfhp = 300;
                bonus += 200;
            }
        }
    }
    public void Delete()
    {
        for (int i = Mathf.RoundToInt(transform.position.x) + xdl; i <= Mathf.RoundToInt(transform.position.x) + xul; i++)
        {
            for (int j = Mathf.RoundToInt(transform.position.y) + ydl; j <= Mathf.RoundToInt(transform.position.y) + yul; j++)
            {
                GameObject.Find("center").GetComponent<MapScr>().Map[i + 15, 12 - j].GetComponent<Tiles>().able = true;
            }
        }
        GameObject.Find("Player").GetComponent<PlayerSystem>().money += selcost;
        BuildingManager buildingManager;
        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();
        buildingManager.RemoveElementOfListToGameObject(gameObject);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (click == false && BUI2.GetComponent<BuildingUIScr>().uion == false)
        {
            click = true;
            UIM.UpgradeUI(gameObject, 3, level, upcost, selcost, fhp, 100, bonus, 200);
        }
    }
    private void OnMouseUp()
    {
        if (click == true)
        {
            click = false;
        }
    }

    IEnumerator SelfHeal()
    {
        while (true)
        {
            if (GameObject.Find("Player").GetComponent<PlayerSystem>().ab1 == true)
            {
                if (fhp < maxfhp)
                {
                    fhp += 1;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


}
