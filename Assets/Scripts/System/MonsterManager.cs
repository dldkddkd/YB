using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {

    public List<GameObject> monsterList = new List<GameObject>();

    public GameObject SkulPrefab;
    public GameObject GhostPrefab;
    public GameObject WhichPrefab;//which->witch
    public GameObject BombPrefab;

    public enum MonsterType {
        SKUL, GHOST, WITCH, BOMB
    };

    public void Start()
    {
        //SetMonster(MonsterType.GHOST, new Vector3(5, 5, 0));

        //SetMonster(MonsterType.GHOST, new Vector3(-7, 5, 0));

        //SetMonster(MonsterType.GHOST, new Vector3(-9, -5, 0));
    }

    public void SetMonster(MonsterType type, Vector3 spawnPos)
    {
        GameObject targetMonster = null;
        if (type == MonsterType.SKUL)
        {
            targetMonster = Instantiate(SkulPrefab, spawnPos, Quaternion.identity);
        }
        else if (type == MonsterType.GHOST)
        {
            targetMonster = Instantiate(GhostPrefab, spawnPos, Quaternion.identity);
        }
        else if (type == MonsterType.WITCH)
        {
            targetMonster = Instantiate(WhichPrefab, spawnPos, Quaternion.identity);
        }
        else if (type == MonsterType.BOMB)
        {
            targetMonster = Instantiate(BombPrefab, spawnPos, Quaternion.identity);
        }

        targetMonster.GetComponent<Monster>().type = type;
        monsterList.Add(targetMonster);
    }

    public void DeadMonster(GameObject gameObj)
    {
        GameObject.Find("Player").GetComponent<PlayerSystem>().money += gameObj.GetComponent<Monster>().getPay();
        monsterList.RemoveAt(monsterList.IndexOf(gameObj));
        Destroy(gameObj, 0.0f);
    }

    public bool IsEmptyMonsterList()
    {
        if (monsterList.Count == 0) return true;
        return false;
    }

    public Vector3 GetCloseMonsterPosition(Vector3 center)
    {
        Vector2 centerVec2 = (Vector2)center;
        GameObject targetMob = null;

        if (IsEmptyMonsterList() == true)
        {
            return Vector3.zero;
        }

        double distance = 999;
        foreach (GameObject obj in monsterList)
        {
            double tempDistance = ((Vector2)obj.transform.position - centerVec2).magnitude;
            if (distance > tempDistance)
            {
                targetMob = obj;
                distance = tempDistance;
            }
        }

        return targetMob.transform.position;
    }

    public float GetCloseMonsterDistance(Vector3 center)
    {
        Vector2 centerVec2 = (Vector2)center;
        GameObject targetMob = null;

        if (IsEmptyMonsterList() == true)
        {
            return 999;
        }

        double distance = 999;
        foreach (GameObject obj in monsterList) 
        {
            double tempDistance = ((Vector2)obj.transform.position - centerVec2).magnitude;
            if (distance > tempDistance)
            {
                targetMob = obj;
                distance = tempDistance;
            }
        }

        return (float)distance;
    }

    public void DealingToMonster(Vector3 pos, int ad, double splash, int penetration)
    {
        Vector2 posVec2 = (Vector2)pos;
        int attackCount = 0;

        foreach (GameObject obj in monsterList)
        {
            if (((Vector2)(obj.transform.position) - posVec2).magnitude < splash)
            {
                int decedHp = obj.GetComponent<Monster>().hp -= ad;
                Debug.Log("Monster.hp: " + decedHp.ToString());
                attackCount++;
                if (attackCount >= penetration) break;
            }
        }
    }
}
