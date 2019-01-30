using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScr : MonoBehaviour {

    public int xul, xdl, yul, ydl;
    private int xpos, ypos;

    void Start () {
        transform.position += new Vector3(0, 0, transform.position.y);

        xpos = Mathf.RoundToInt(transform.position.x) + 15;
        ypos = -Mathf.RoundToInt(transform.position.y) + 12;

        for (int i = xdl; i <= xul; i++)
        {
            for (int j = ydl; j <= yul; j++)
            {
                if (GameObject.Find("center") != null)
                {
                    GameObject.Find("center").GetComponent<MapScr>().Map[xpos + i, ypos + j].GetComponent<Tiles>().able = false;
                    //.Log((xpos + i) + " " + (ypos + j));
                }
            }
        }
    }
	
	void Update () {
	}
}
