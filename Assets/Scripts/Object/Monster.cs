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
    float moveSpeed;
    int pay;
    public MonsterManager.MonsterType type;

    float attackRegister;

    BuildingManager buildingManager;
    Building home;
    public GameObject atkPrefab;
    public GameObject player;

    public void Start()
    {
        attackRegister = 0;
        player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        if (type == MonsterManager.MonsterType.SKUL)
        {
            hp = 60;
            atk = 30;
            atkRange = 1;
            atkSpeed = 1.5f;
            moveSpeed = 2;
            pay = 10;

        }
        else if (type == MonsterManager.MonsterType.GHOST)
        {
            hp = 45;
            atk = 20;
            atkRange = 3;
            atkSpeed = 1;
            moveSpeed = 1.5f;
            pay = 15;
        }
        else if (type == MonsterManager.MonsterType.WITCH)
        {
            hp = 500;
            atk = 100;
            atkRange = 6;
            atkSpeed = 0.2f;
            moveSpeed = 1.5f;
            pay = 100;
        }
        else if (type == MonsterManager.MonsterType.BOMB)
        {
            hp = 20;
            atk = 1000;
            atkRange = 1;
            atkSpeed = 1;
            moveSpeed = 0.75f;
            pay = 20;
        }


        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();

    }

    public void Update()
    {

        if (this.hp <= 0)
        {
            MonsterManager monsterManager = GameObject.Find("center").GetComponent<MonsterManager>();
            monsterManager.DeadMonster(gameObject);
        }

        Building building;
        this.home = buildingManager.home;
        building = buildingManager.GetMostCloseBuilding(transform.position);

        float pDistance = 0;
        if (player != null){
            pDistance = ((Vector2)player.transform.position - (Vector2)this.transform.position).magnitude;
        }

        if (building.GetBetweenDistanceFloat(transform.position) < atkRange || (player != null  &&pDistance < atkRange))
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
        if (type == MonsterManager.MonsterType.BOMB && 1 <= attackRegister && attackRegister <= 10)
        {
            GameObject bullet = null;
            bullet = Instantiate(atkPrefab, this.transform.position, Quaternion.identity);

            GhostAttack attackInfo = bullet.GetComponent<GhostAttack>();
            attackInfo.ad = atk;
            attackInfo.attackRange = 1;

            GameObject.Find("center").GetComponent<MonsterManager>().DeadMonster(gameObject);
        }

        if (attackRegister > 0) return;

        if (type == MonsterManager.MonsterType.BOMB)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("explsion");
        }
        else
        {
            GameObject bullet = null;
            bullet = Instantiate(atkPrefab, this.transform.position, Quaternion.identity);

            if (type == MonsterManager.MonsterType.SKUL)
            {
                GhostAttack attackInfo = bullet.GetComponent<GhostAttack>();
                attackInfo.ad = atk;
                attackInfo.attackRange = atkRange;
                attackInfo.speed = 1;
            }
            else if (type == MonsterManager.MonsterType.GHOST)
            {
                GhostAttack attackInfo = bullet.GetComponent<GhostAttack>();
                attackInfo.ad = atk * 2;
                attackInfo.attackRange = atkRange;
                attackInfo.speed = 2;
            }
            else if (type == MonsterManager.MonsterType.WITCH)
            {
                GhostAttack attackInfo = bullet.GetComponent<GhostAttack>();
                attackInfo.ad = atk * 2;
                attackInfo.attackRange = atkRange;
                attackInfo.speed = 3;
            }
        }


        attackRegister = 60;
    }

    public int getPay()
    {
        return pay;
    }
}
