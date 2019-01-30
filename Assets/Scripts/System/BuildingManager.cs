using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private int mapSizeX = 32;
    private int mapSizeY = 24;

    public enum BuildingType
    {
        NONE, HOME, WIDTHWALL, HEIGHTWALL, TOWER, FARM
    };

    public Vector2 pos;
    public BuildingType type;
    public int hp;
    public int curHp;
    public int ad;
    public int level;
    public GameObject desktop;  // 해당 위치에 생기는 게임 오브젝트

    public Vector3 GetBetweenDistanceVector3(Vector3 pos)
    {
        Vector3 tempPos = (Vector3)this.pos;
        tempPos.x -= 15.5f;
        tempPos.y -= 15.5f;
        return (tempPos - pos);
    }
    public float GetBetweenDistanceFloat(Vector3 pos)
    {
        Vector3 tempPos = (Vector3)this.pos;
        tempPos.x -= 15.5f;
        tempPos.y -= 15.5f;
        return (tempPos - pos).magnitude;
    }

}

public class BuildingManager : MonoBehaviour
{

    public List<Building> buildingList = new List<Building>();
    public Building home;

    public void Start()
    {
        home = AddBuilding(GameObject.Find("home").gameObject, 16, 16, Building.BuildingType.HOME);
    }

    public Building AddBuilding(GameObject tmp, int x_, int y_, Building.BuildingType type)
    {
        Building targetBuilding = new Building();

        targetBuilding.desktop = tmp;
        targetBuilding.pos = new Vector2(x_, y_);
        targetBuilding.type = type;
        targetBuilding.level = 1;

        targetBuilding.hp = 500;
        targetBuilding.ad = 0;

        if (type == Building.BuildingType.WIDTHWALL) targetBuilding.hp = 500;
        else if (type == Building.BuildingType.HEIGHTWALL) targetBuilding.hp = 500;
        else if (type == Building.BuildingType.TOWER) targetBuilding.hp = 1000;
        else if (type == Building.BuildingType.FARM) targetBuilding.hp = 100;
        else if (type == Building.BuildingType.HOME) targetBuilding.hp = 5000;

        targetBuilding.curHp = targetBuilding.hp;

        if (type == Building.BuildingType.WIDTHWALL) targetBuilding.ad = 0;
        else if (type == Building.BuildingType.HEIGHTWALL) targetBuilding.ad = 0;
        else if (type == Building.BuildingType.TOWER) targetBuilding.ad = 30;
        else if (type == Building.BuildingType.FARM) targetBuilding.ad = 100;
        else if (type == Building.BuildingType.HOME) targetBuilding.ad = 0;

        buildingList.Add(targetBuilding);

        return targetBuilding;
    }

    public void UpgradeBuilding(Building building)
    {

        if (building.type == Building.BuildingType.WIDTHWALL)
        {
            if (building.level == 1)
            {
                building.hp = 1000;
                building.curHp = building.hp;
                building.level = 2;
            }
            else if (building.level == 2)
            {
                building.hp = 1500;
                building.curHp = building.hp;
                building.level++;
            }
            else if (building.level == 3)
            {
                return;
            }
        }
        else if (building.type == Building.BuildingType.HEIGHTWALL)
        {
            if (building.level == 1)
            {
                building.hp = 1000;
                building.curHp = building.hp;
                building.level = 2;
            }
            else if (building.level == 2)
            {
                building.hp = 1500;
                building.curHp = building.hp;
                building.level++;
            }
            else if (building.level == 3)
            {
                return;
            }
        }
        else if (building.type == Building.BuildingType.TOWER)
        {
            if (building.level == 1)
            {
                building.hp = 1300;
                building.curHp = building.hp;
                building.ad = 50;
                building.level = 2;
            }
            else if (building.level == 2)
            {
                building.hp = 1600;
                building.curHp = building.hp;
                building.ad = 70;
                building.level++;
            }
            else if (building.level == 3)
            {
                return;
            }
        }
        else if (building.type == Building.BuildingType.FARM)
        {
            if (building.level == 1)
            {
                building.hp = 200;
                building.curHp = building.hp;
                building.ad = 300;
                building.level = 2;
            }
            else if (building.level == 2)
            {
                building.hp = 300;
                building.curHp = building.hp;
                building.ad = 500;
                building.level++;
            }
            else if (building.level == 3)
            {
                return;
            }
        }
        else if (building.type == Building.BuildingType.HOME)
        {
            if (building.level == 1)
            {
                return;
            }
        }
    }

    public Building GetMostCloseBuilding(Vector3 pos)   // transform.position으로 비교
    {
        double distance = 999;
        Building target = null;
        Vector3 tempPos;
        foreach (Building item in buildingList)
        {
            tempPos = (Vector3)item.pos;
            tempPos.x -= 15.5f;
            tempPos.y -= 15.5f;

            double tempDistance = (pos - tempPos).magnitude;
            //Debug.Log("tempDistance: " + tempDistance.ToString());
            if (distance > tempDistance)
            {
                // Debug.Log("세상은 바뀐다");
                target = item;
                distance = tempDistance;
            }
        }
        return target;
    }

    public Building GetTheBuilding(Vector3 transVec3, Building.BuildingType type)
    {
        Vector3 tempPos;
        Building target = null;

        foreach (Building item in buildingList)
        {
            if (item.type != type) continue;

            tempPos = (Vector3)item.pos;

            if (type == Building.BuildingType.HOME)
            {
                tempPos.x -= 15.5f;
                tempPos.y -= 15.5f;
            }
            double tempDistance = (transVec3 - tempPos).magnitude;
            // Debug.Log("distance: " + tempDistance.ToString());
            Debug.Log(type.ToString() + "  tempPos: " + tempPos.ToString());
            if (tempDistance < 0.3f)
            {
                Debug.Log("세상은 바뀐다.:");
                target = item;
                return target;
            }
        }
        return null;
    }

    public void RemoveElementOfListToGameObject(GameObject gameObj)
    {
        foreach (Building bd in buildingList)
        {
            if (bd.desktop == gameObj)
            {
                buildingList.RemoveAt(buildingList.IndexOf(bd));
                return;
            }
        }
        return;
    }
}