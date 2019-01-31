using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{

    Building targetBuilding;
    BuildingManager buildingManager;
    Vector3 startPoint;
    Vector3 attackArrow;
    public float speed = 1.0f;
    public float attackRange = 2.1f;
    public int ad = 20;

    private GameObject player;
    private float pDistance;
    private float bDistance;
    private bool targetIsPlayer;

    public void Start()
    {
        try
        {

            startPoint = transform.position;
            buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();


            targetBuilding = buildingManager.GetMostCloseBuilding(transform.position);
            attackArrow = (Vector3)((Vector2)(targetBuilding.GetBetweenDistanceVector3(startPoint))).normalized;
            float theta = Mathf.Sign(attackArrow.y) * Mathf.Acos(Mathf.Abs(attackArrow.x) / Mathf.Sqrt(attackArrow.x * attackArrow.x + attackArrow.y * attackArrow.y)) * Mathf.Rad2Deg;
            if (attackArrow.x < 0)
            {
                theta = 180 - theta;
            }
            transform.Rotate(new Vector3(0, 0, 180 + theta));

            player = GameObject.Find("Player").transform.GetChild(0).gameObject;

        }
        catch { }
    }

    public void Update()
    {
        if (targetBuilding == null)
        {
            targetBuilding = buildingManager.GetMostCloseBuilding(transform.position);

            bDistance = targetBuilding.GetBetweenDistanceFloat(this.transform.position);
        }
        pDistance = 999;

        try
        {
            player = GameObject.Find("Player").transform.GetChild(0).gameObject;
        }
        catch { }
        if (player == null)
        {
            try
            {
                player = GameObject.Find("Player").transform.GetChild(0).gameObject;
                pDistance = ((Vector2)player.transform.localPosition - (Vector2)this.transform.position).magnitude;
            }
            catch
            {
            }
        }
        else
        {
            pDistance = ((Vector2)player.transform.localPosition - (Vector2)this.transform.position).magnitude;
        }

        if (pDistance < bDistance)
        {
            attackArrow = (Vector3)((Vector2)player.transform.localPosition - (Vector2)this.transform.position).normalized;
            targetIsPlayer = true;
        }
        else
        {
            attackArrow = (Vector3)((Vector2)(targetBuilding.GetBetweenDistanceVector3(startPoint))).normalized;
            targetIsPlayer = false;
        }

        if (targetBuilding == null) Destroy(gameObject, 0.0f);

        if (targetIsPlayer = false && bDistance < 0.5f)
        {
            if (targetBuilding.type == Building.BuildingType.HOME)
            {
                GameObject.Find("home").GetComponent<HomeScript>().hp -= ad;
            }
            targetBuilding.hp -= ad;
            Debug.Log("targetBuilding.hp: " + targetBuilding.hp);
            Destroy(gameObject, 0.0f);
        }
        else if (targetIsPlayer = true && pDistance < 0.5f)
        {
            if (player == null)
            {
                player = GameObject.Find("Player").transform.GetChild(0).gameObject;

            }
            player.GetComponent<PlayerMove>().BeAttack(ad);
            Debug.Log("player.hp: " + targetBuilding.hp);
            Destroy(gameObject, 0.0f);
        }

        if (((Vector2)transform.position - (Vector2)startPoint).magnitude > attackRange)
        {
            Destroy(gameObject, 0.0f);
        }
        transform.position += (attackArrow * speed * Time.deltaTime);
    }
}