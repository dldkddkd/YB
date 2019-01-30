using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour {

    public Vector3 arrow;
    public Vector3 startPoint;
    public int ad;      // 공격력
    public double range;    // 사정거리
    public float speed;    // 투사체 속도
    public double splash;   // 스플래시(범위공격)
    public int penetration; // 관통

    MonsterManager mobManager;

    private void Start()
    {
        mobManager = GameObject.Find("center").GetComponent<MonsterManager>();
        startPoint = transform.position;
    }
    private void Update()
    {
        if (mobManager.GetCloseMonsterDistance(this.transform.position) < splash)
        {
            mobManager.DealingToMonster( transform.position,  ad,  splash,  penetration);
            Destroy(gameObject, 0.0f);
        }

        transform.position += (arrow * speed * Time.deltaTime);

        if (((Vector2)startPoint - (Vector2)transform.position).magnitude > range)
        {
            Destroy(gameObject, 0.0f);
        }
    }
}
