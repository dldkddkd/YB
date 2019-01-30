using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerupgrade : MonoBehaviour {

    public int xul, xdl, yul, ydl;
    private int level;
    public int thp, atk;
    private bool click;
    private int upcost, selcost;
    public Sprite lv1spr, lv2spr, lv3spr;

    private UIManager UIM;

    void Start()
    {
        GetComponent<WallScr>().xul = xul;
        GetComponent<WallScr>().xdl = xdl;
        GetComponent<WallScr>().yul = yul;
        GetComponent<WallScr>().ydl = ydl;

        level = 1;
        thp = 1000;
        atk = 30;
        click = false;
        upcost = 180;
        selcost = 40;
        GetComponent<SpriteRenderer>().sprite = lv1spr;

        UIM = GameObject.Find("UIs").GetComponent<UIManager>();
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
                thp = 1300;
                atk += 20;
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lv3spr;
                thp = 1500;
                atk += 20;
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
        if (click == false)
        {
            click = true;
            UIM.UpgradeUI(gameObject, 2, upcost, selcost, thp, 200, atk, 20);
        }
        else
        {
            click = false;
        }
    }
}
