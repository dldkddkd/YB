using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallupgrade : MonoBehaviour {

    public int xul, xdl, yul, ydl;
    private int level;
    public int whp;
    private bool click;
    private int upcost, selcost;
    public Sprite lv1spr, lv2spr, lv3spr;

    private UIManager UIM;

    void Start ()
    {
        GetComponent<WallScr>().xul = xul;
        GetComponent<WallScr>().xdl = xdl;
        GetComponent<WallScr>().yul = yul;
        GetComponent<WallScr>().ydl = ydl;

        level = 1;
        whp = 500;
        click = false;
        upcost = 80;
        selcost = 20;
        GetComponent<SpriteRenderer>().sprite = lv1spr;

        UIM = GameObject.Find("UIs").GetComponent<UIManager>();
    }
	
	void Update () {
    }

    public void Upgrade()
    {
        if (level < 3)
        {
            level += 1;
            if (level == 2)
            {
                GetComponent<SpriteRenderer>().sprite = lv2spr;
                whp = 1000;
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lv3spr;
                whp = 1500;
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
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (click == false)
        {
            click = true;
            UIM.UpgradeUI(gameObject, 1, upcost, selcost, whp, 500, 0, 0);
        }
        else
        {
            click = false;
        }
    }
}
