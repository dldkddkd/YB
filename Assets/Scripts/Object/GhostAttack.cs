using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{

    Building targetBuilding;
    BuildingManager buildingManager;
    Vector3 startPoint;
    Vector3 attackArrow;

    public void Start()
    {
        startPoint = transform.position;
        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();
        targetBuilding = buildingManager.GetMostCloseBuilding(transform.position);
        attackArrow = (Vector3)((Vector2)(targetBuilding.GetBetweenDistanceVector3(startPoint))).normalized;
    }

    public void Update()
    {
        if (targetBuilding == null) Destroy(gameObject, 0.0f);
        if (targetBuilding.GetBetweenDistanceFloat(transform.position) < 0.5f)
        {
            targetBuilding.hp -= 20;
            Debug.Log("targetBuilding.hp: " + targetBuilding.hp);
            Destroy(gameObject, 0.0f);
        }

        if (((Vector2)transform.position - (Vector2)startPoint).magnitude > 3.1f)
        {
            Destroy(gameObject, 0.0f);
        }
        transform.position += (attackArrow * Time.deltaTime);
    }
}
