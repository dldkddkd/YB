using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{

    Building targetBuilding;
    BuildingManager buildingManager;
    Vector3 startPoint;
    Vector3 attackArrow;
    Vector3 arrayPos;

    public void Start()
    {
        startPoint = transform.position;
        buildingManager = GameObject.Find("center").GetComponent<BuildingManager>();
        targetBuilding = buildingManager.GetMostCloseBuilding(transform.position);
        //startPoint = this.transform.position;
        //arrayPos = transform.position - new Vector3(15.5f, 15.5f, 0);
        //targetBuilding= buildingManager.GetMostCloseBuilding(arrayPos);
        //targetBuilding.pos.x -= 15.5f;
        //targetBuilding.pos.y -= 15.5f;
        attackArrow = targetBuilding.GetBetweenDistanceVector3(startPoint).normalized;
        //attackArrow = attackArrow.normalized;
    }

    public void Update()
    {
        if (targetBuilding == null) Destroy(gameObject, 0.1f);
        if (targetBuilding.GetBetweenDistanceFloat(transform.position) < 0.5f)
        {
            targetBuilding.hp -= 20;
            Destroy(gameObject, 0.1f);
        }

        if ((transform.position - startPoint).magnitude > 2.0f)
        {
            Destroy(gameObject, 0.1f);
        }
        transform.position += (attackArrow * Time.deltaTime);
    }
}
