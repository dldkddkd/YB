using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallupgrade : MonoBehaviour {

    private int level;
    public int whp;
    public Sprite lv1spr, lv2spr, lv3spr;

    void Start ()
    {
        level = 1;
        whp = 500;
        GetComponent<SpriteRenderer>().sprite = lv1spr;
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
}
