using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    private int stage;
    private UIManager UIM;

    private bool game;
    private int enemy;

    private GameObject Enemy1;
    private GameObject Enemy2;
    private GameObject Enemy3;
    private GameObject Enemy4;
    private GameObject Enemy5;

    void Start () {
        stage = 1;
        UIM = GameObject.Find("UIs").GetComponent<UIManager>();

        game = false;

        UIM.StageEnd(stage);
        Enemy1 = Resources.Load("Enemy1") as GameObject;

    }
	
	void Update () {
        if (game == false)
        {
        }
        else
        {
            if (enemy == 0)
            {
                game = false;
                stage += 1;
                UIM.StageEnd(stage);
            }
        }
	}
    public void StageStart()
    {
        if (stage == 1)
        {
            StartCoroutine(Stage1());
        }
    }

    IEnumerator Stage1()
    {
        while (true)
        {
            game = true;
            enemy = 5; //적 수
            //spawn
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(1, 1, 1);
            }
            yield return new WaitForSeconds(1.0f);

            yield break;
        }
    }

    void Create_Enemy(int type, int dir1, int dir2)    //right=1, left=-1 / down=-1, up=1
    {
        GameObject spawn = null;
        Vector3 tmp = new Vector3(0, 0, 5);
        float xrand = Random.Range(-2.0f, 2.0f);
        float yrand = Random.Range(-2.0f, 2.0f);

        if (dir1 == 1)
        {
            tmp.x += 18;
        }
        else if (dir1 == -1)
        {
            tmp.x -= 18;
        }
        if (dir2 == 1)
        {
            tmp.y += 12;
            tmp.z += 12;
        }
        else if (dir2 == -1)
        {
            tmp.y -= 12;
            tmp.z -= 12;
        }
        tmp.x += xrand;
        tmp.y += yrand;

        if (type == 1)
        {
            spawn = Enemy1;
        }

        Instantiate(spawn, tmp, Quaternion.Euler(0, 0, 0));
    }
}
