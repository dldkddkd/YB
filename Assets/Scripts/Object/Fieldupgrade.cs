using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldupgrade : MonoBehaviour {

    private int level;
    public int fhp, bonus;
    public Sprite lv1spr, lv2spr, lv3spr;

    void Start()
    {
        level = 1;
        fhp = 100;
        bonus = 100;
        GetComponent<SpriteRenderer>().sprite = lv1spr;
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
                bonus += 200;
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lv3spr;
                fhp = 300;
                bonus += 200;
            }
        }
    }
}
