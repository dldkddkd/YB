using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Vector2 pos;
    public int hp;
    int atk;
    int atkRange;
    float atkSpeed;
    int moveSpeed;

    float attackRegister;

    BuildingManager buildingManager;
    Building home;
    public GameObject atkPrefab;

    public void Awake()
    {
        //pos = Vector2.zero;
        hp = 1;
        atk = 1;
        atkRange = 2;
        atkSpeed = 1;
        moveSpeed = 1;

        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();

    }

    public void Update()
    {
        Building building;
        this.home = buildingManager.home;
        building = buildingManager.GetMostCloseBuilding(transform.position);

        if (this.hp <= 0)
        {
            MonsterManager monsterManager = GameObject.Find("center").GetComponent<MonsterManager>();
            monsterManager.DeadMonster(gameObject);
        }

        if (building.GetBetweenDistanceFloat(transform.position) < atkRange)
        {
            attack();
        }
        else
        {
            goToHome();
        }
        attackRegister -= atkSpeed;
    }

    public virtual void goToHome()
    {

        Vector3 fixedArrow = (home.GetBetweenDistanceVector3(transform.position)).normalized;
        //fixedArrow *= -1;
        this.transform.position += (fixedArrow * this.moveSpeed * Time.deltaTime);
    }


    public virtual void attack()
    {
        if (attackRegister > 0) return;

        Instantiate(atkPrefab, this.transform.position, Quaternion.identity);

        attackRegister = 60;
    }

}
