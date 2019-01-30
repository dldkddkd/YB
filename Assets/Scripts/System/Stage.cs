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
        stage = 0;
        UIM = GameObject.Find("UIs").GetComponent<UIManager>();

        game = false;

        //Enemy1 = Resources.Load("Enemy1") as GameObject;

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
            }
        }
	}

    IEnumerator Stage1()
    {
        while (true)
        {
            game = true;
            enemy = 10; //적 수
            //spawn
            yield return new WaitForSeconds(1.0f);

            yield break;
        }
    }

    void Create_Enemy(int type, int locate)
    {
    }
}
