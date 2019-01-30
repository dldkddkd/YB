using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCreate : MonoBehaviour {

    private int num, xul, xdl, yul, ydl;
    public Sprite b1, b2, b3, b4;
    private GameObject creation;

	void Start ()
    {
    }
	
	void Update () {
        transform.position = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if (Input.GetMouseButtonDown(1))
        {
            Off();
        }
    }

    public void On(int bnum)
    {
        num = bnum;
        if (bnum == 1)
        {
            GetComponent<SpriteRenderer>().sprite = b1;
            creation = Resources.Load("1x3Wall") as GameObject;
            transform.localScale = creation.transform.localScale;
        }
        else if (bnum == 2)
        {
            GetComponent<SpriteRenderer>().sprite = b2;
            creation = Resources.Load("3x1Wall") as GameObject;
            transform.localScale = creation.transform.localScale;
        }
        else if (bnum == 3)
        {
            GetComponent<SpriteRenderer>().sprite = b3;
            creation = Resources.Load("Tower1") as GameObject;
            transform.localScale = creation.transform.localScale;
        }
        else if (bnum == 4)
        {
            GetComponent<SpriteRenderer>().sprite = b4;
            creation = Resources.Load("Field") as GameObject;
            transform.localScale = creation.transform.localScale;
        }
    }

    void Off()
    {
        gameObject.SetActive(false);
    }

    public void Create(float cx, float cy)
    {
        bool able = true;
        if (num == 1)
        {
            xul = 0;
            xdl = 0;
            yul = 1;
            ydl = -1;
        }
        else if (num == 2)
        {
            xul = 1;
            xdl = -1;
            yul = 0;
            ydl = 0;
        }
        else if (num == 3 || num == 4)
        {
            xul = 0;
            xdl = 0;
            yul = 0;
            ydl = 0;
        }
        for (int i = Mathf.RoundToInt(cx) + xdl; i <= Mathf.RoundToInt(cx) + xul; i++)
        {
            for (int j = Mathf.RoundToInt(cy) + ydl; j <= Mathf.RoundToInt(cy) + yul; j++)
            {
                if (GameObject.Find("center").GetComponent<MapScr>().Map[i + 15, 12 - j].GetComponent<Tiles>().able == false)
                {
                    able = false;
                }
            }
        }

        if (able == true)
        {
            GameObject tmp = Instantiate(creation, new Vector3(cx, cy, 5), Quaternion.Euler(0, 0, 0));
            tmp.GetComponent<WallScr>().xul = xul;
            tmp.GetComponent<WallScr>().xdl = xdl;
            tmp.GetComponent<WallScr>().yul = yul;
            tmp.GetComponent<WallScr>().ydl = ydl;
            Off();
        }
    }
}
