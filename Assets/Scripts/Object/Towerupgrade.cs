using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerupgrade : MonoBehaviour {

    public int xul, xdl, yul, ydl;
    private int level;
    public int thp, maxthp, atk;
    private bool click;
    private int upcost, selcost;
    private float atkRange, atkSpeed;   // 사정거리, 공격속도
    private float atkRegister = 0;          // 공격쿨타임용 레지스터
    private float bulletSpeed;
    public Sprite lv1spr, lv2spr, lv3spr;

    private UIManager UIM;
    private GameObject BUI2;
    private Animator animator;
    private MonsterManager mobManager;

    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;

    void Start()
    {
        GetComponent<WallScr>().xul = xul;
        GetComponent<WallScr>().xdl = xdl;
        GetComponent<WallScr>().yul = yul;
        GetComponent<WallScr>().ydl = ydl;

        level = 1;
        thp = 1000;
        maxthp = 1000;
        atk = 30;
        click = false;
        upcost = 180;
        selcost = 40;
        atkRange = 4;
        atkSpeed = 1;
        bulletSpeed = 2;
        GetComponent<SpriteRenderer>().sprite = lv1spr;

        UIM = GameObject.Find("UIs").GetComponent<UIManager>();
        BUI2 = UIM.Upgrade.gameObject;
        animator = transform.GetComponent<Animator>();
        mobManager = GameObject.Find("center").GetComponent<MonsterManager>();
    }

    void Update()
    {
        if (mobManager.IsEmptyMonsterList() == false)
        {
            Vector3 aim = mobManager.GetCloseMonsterPosition(this.transform.position);
            if (((Vector2)transform.position - (Vector2)aim).magnitude < atkRange)
            {
                attack(aim);
            }
        }
        atkRegister -= atkSpeed;
    }

    public void Upgrade()
    {
        if (level < 3)
        {
            level += 1;
            if (level == 2)
            {
                GetComponent<SpriteRenderer>().sprite = lv2spr;
                thp = 1300;
                maxthp = 1300;
                atk += 20;
                bulletSpeed = 3.5f;
                atkRange += 2;
                animator.SetInteger("level", 1);
            }
            else if (level == 3)
            {
                GetComponent<SpriteRenderer>().sprite = lv3spr;
                thp = 1500;
                maxthp = 1500;
                atk += 20;
                bulletSpeed = 7.0f;
                atkRange += 2;
                animator.SetInteger("level", 2);
            }
        }
    }
    public void Delete()
    {
        for (int i = Mathf.RoundToInt(transform.position.x) + xdl; i <= Mathf.RoundToInt(transform.position.x) + xul; i++)
        {
            for (int j = Mathf.RoundToInt(transform.position.y) + ydl; j <= Mathf.RoundToInt(transform.position.y) + yul; j++)
            {
                GameObject.Find("center").GetComponent<MapScr>().Map[i + 15, 12 - j].GetComponent<Tiles>().able = true;
            }
        }
        GameObject.Find("Player").GetComponent<PlayerSystem>().money += selcost;

        BuildingManager buildingManager;
        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();
        buildingManager.RemoveElementOfListToGameObject(gameObject);

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (click == false && BUI2.GetComponent<BuildingUIScr>().uion == false)
        {
            click = true;
            UIM.UpgradeUI(gameObject, 2, level, upcost, selcost, thp, 200, atk, 20);
        }
    }
    private void OnMouseUp()
    {
        if (click == true)
        {
            click = false;
        }
    }

    public void attack(Vector3 aim)
    {
        animator.SetBool("cool", true);
        StartCoroutine(Cool());
        if (atkRegister > 0) return;

        GameObject bulletObj = null;
        if (this.level == 1) bulletObj = Instantiate(Bullet1, gameObject.transform.position, Quaternion.identity);
        else if (this.level == 2) bulletObj = Instantiate(Bullet2, gameObject.transform.position, Quaternion.identity);
        else if (this.level == 3) bulletObj = Instantiate(Bullet3, gameObject.transform.position, Quaternion.identity);

        BulletInfo bulletInfo = null;
        bulletInfo = bulletObj.GetComponent<BulletInfo>();
        
        bulletInfo.arrow = (Vector3)((Vector2)aim - (Vector2)this.transform.position).normalized;
        float theta = Mathf.Sign(bulletInfo.arrow.y) * Mathf.Acos(Mathf.Abs(bulletInfo.arrow.x) / Mathf.Sqrt(bulletInfo.arrow.x * bulletInfo.arrow.x + bulletInfo.arrow.y * bulletInfo.arrow.y)) * Mathf.Rad2Deg;
        if (bulletInfo.arrow.x < 0)
        {
            theta = 180 - theta;
        }
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.Rotate(new Vector3(0, 0, theta + 90));

        bulletInfo.ad = this.atk;
        bulletInfo.range = this.atkRange;
        bulletInfo.speed = this.bulletSpeed;

        if (this.level == 1)
        {
            bulletInfo.splash = 0.1;
            bulletInfo.penetration = 1;
        }
        else if (this.level == 2)
        {
            bulletInfo.splash = 0.2;
            bulletInfo.penetration = 3;
        }
        else if (this.level == 3)
        {
            bulletInfo.splash = 0.2;
            bulletInfo.penetration = 5;
        }

        atkRegister = 60;
    }
    IEnumerator Cool()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("cool", false);
            yield break;
        }
    }
    IEnumerator SelfHeal()
    {
        while (true)
        {
            if (GameObject.Find("Player").GetComponent<PlayerSystem>().ab1 == true)
            {
                if (thp < maxthp)
                {
                    thp += 1;
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
