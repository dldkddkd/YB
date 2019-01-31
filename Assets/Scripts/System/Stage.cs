using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

    private int stage;
    private UIManager UIM;
    private MonsterManager MM;

    private bool game;
    private int enemy;

    private GameObject Enemy1;
    private GameObject Enemy2;
    private GameObject Enemy3;
    private GameObject Enemy4;

    void Start () {
        stage = 1;
        UIM = GameObject.Find("UIs").GetComponent<UIManager>();
        MM = GameObject.Find("center").GetComponent<MonsterManager>();

        game = false;

        UIM.StageEnd(stage);
        Enemy1 = Resources.Load("Enemy1") as GameObject;
        Enemy2 = Resources.Load("Enemy2") as GameObject;
        Enemy3 = Resources.Load("Enemy3") as GameObject;
        Enemy4 = Resources.Load("Enemy4") as GameObject;

    }
	
	void Update () {
        if (game == false)
        {
        }
        else
        {
            if (MM.IsEmptyMonsterList() == true)
            {
                game = false;
                int sum = GameObject.Find("center").GetComponent<BuildingManager>().SearchFarm();
                GameObject.Find("Player").GetComponent<PlayerSystem>().money += 200 + 10 * stage + sum;
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
        else if (stage == 2)
        {
            StartCoroutine(Stage2());
        }
        else if (stage == 3)
        {
            StartCoroutine(Stage3());
        }
        else if (stage == 4)
        {
            StartCoroutine(Stage4());
        }
        else if (stage == 5)
        {
            StartCoroutine(Stage5());
        }
        else if (stage == 6)
        {
            StartCoroutine(Stage6());
        }
        else if (stage == 7)
        {
            StartCoroutine(Stage7());
        }
        else if (stage == 8)
        {
            StartCoroutine(Stage8());
        }
        else if (stage == 9)
        {
            StartCoroutine(Stage9());
        }
        else if (stage >= 10)
        {
            StartCoroutine(Stage10());
        }
    }

    IEnumerator Stage1()
    {
        enemy = 1;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(1, 1, 1);
                Create_Enemy(1, 1, 0);
                Create_Enemy(1, 1, -1);
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage2()
    {
        enemy = 2;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(1, 0, 1);
                Create_Enemy(1, 1, 0);
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage3()
    {
        enemy = 3;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(1, -1, 0);
                Create_Enemy(1, 1, 0);
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage4()
    {
        enemy = 5;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(1, 0, 1);
                Create_Enemy(1, 0, -1);
                if (i > 3)
                {
                    Create_Enemy(2, -1, 0);
                    Create_Enemy(2, -1, 0);
                }
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage5()
    {
        enemy = 5;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(2, -1, 1);
                Create_Enemy(2, -1, 0);
                Create_Enemy(2, -1, -1);
                if (i > 3)
                {
                    Create_Enemy(1, 0, 1);
                    Create_Enemy(1, 0, -1);
                }
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage6()
    {
        enemy = 5;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(2, 1, 1);
                Create_Enemy(2, 1, 0);
                Create_Enemy(2, 1, 0);
                Create_Enemy(2, 1, -1);
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage7()
    {
        enemy = 5;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                Create_Enemy(2, 1, 1);
                Create_Enemy(2, 1, -1);
                Create_Enemy(2, -1, 1);
                Create_Enemy(2, -1, -1);
                Create_Enemy(1, 1, 0);
                Create_Enemy(1, 0, 1);
                Create_Enemy(1, -1, 0);
                Create_Enemy(1, 0, -1);
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage8()
    {
        enemy = 8;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                if (i % 2 == 0)
                {
                    Create_Enemy(2, 1, 0);
                    Create_Enemy(1, -1, 0);
                }
                else
                {
                    Create_Enemy(1, 1, 1);
                    Create_Enemy(1, -1, -1);
                }
                if (i == 6)
                {
                    Create_Enemy(3, 0, 1);
                    Create_Enemy(3, 0, -1);
                }
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage9()
    {
        enemy = 8;
        while (true)
        {
            for (int i = 0; i < enemy; i++)
            {
                if (i % 2 == 0)
                {
                    Create_Enemy(2, 1, -1);
                    Create_Enemy(1, -1, -1);
                }
                else
                {
                    Create_Enemy(2, -1, 1);
                    Create_Enemy(1, 1, 1);
                }

                if (i == 2)
                {
                    Create_Enemy(3, 1, 0);
                    Create_Enemy(3, -1, 0);
                }
                else if (i == 5)
                {
                    Create_Enemy(3, -1, 1);
                    Create_Enemy(3, 0, 1);
                    Create_Enemy(3, 1, 1);
                }
                else if (i == 8)
                {
                    Create_Enemy(4, 1, 1);
                }
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }
    IEnumerator Stage10()
    {
        enemy = 15;
        while (true)
        {
            Create_Enemy(4, 1, 0);
            Create_Enemy(4, -1, 0);
            for (int i = 0; i < enemy; i++)
            {
                if (i % 2 == 0)
                {
                    Create_Enemy(2, -1, 0);
                    Create_Enemy(1, -1, -1);
                    Create_Enemy(1, -1, 1);
                    Create_Enemy(2, -1, 0);
                    Create_Enemy(1, -1, -1);
                    Create_Enemy(1, -1, 1);
                }
                else
                {
                    Create_Enemy(2, 1, 0);
                    Create_Enemy(1, 1, -1);
                    Create_Enemy(1, 1, 1);
                    Create_Enemy(2, 1, 0);
                    Create_Enemy(1, 1, -1);
                    Create_Enemy(1, 1, 1);
                }

                if (i == 5)
                {
                    Create_Enemy(3, 0, 1);
                    Create_Enemy(3, 0, -1);
                }
                else if (i == 10)
                {
                    Create_Enemy(3, 1, 0);
                    Create_Enemy(3, -1, 0);
                }
                yield return new WaitForSeconds(1.0f);
            }

            game = true;
            yield break;
        }
    }

    void Create_Enemy(int type, int dir1, int dir2)    //right=1, left=-1 / down=-1, up=1
    {
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
            MM.SetMonster(MonsterManager.MonsterType.GHOST, tmp);
        }
        if (type == 2)
        {
            MM.SetMonster(MonsterManager.MonsterType.SKUL, tmp);
        }
        if (type == 3)
        {
            MM.SetMonster(MonsterManager.MonsterType.BOMB, tmp);
        }
        if (type == 4)
        {
            MM.SetMonster(MonsterManager.MonsterType.WITCH, tmp);
        }
    }
}
