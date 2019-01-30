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
    public Vector3 transPosition;
    public BuildingType type;
    public int hp;
    public int curHp;
    public int ad;
    public int level;
    public GameObject desktop;  // 해당 위치에 생기는 게임 오브젝트

    public Vector3 GetBetweenDistanceVector3(Vector3 pos)
    {
        return this.transPosition - pos;
    }
    public float GetBetweenDistanceFloat(Vector3 pos)
    {
        //Debug.Log(this.type + " " + ((Vector2)this.transPosition - (Vector2)pos).magnitude);
        // z축의 거리를 없애기위해 Vector2로 변환
        //Debug.Log(type + " " + ((Vector2)this.transPosition).ToString() + " " + ((Vector2)pos).ToString() + " " + ((Vector2)this.transPosition - (Vector2)pos).magnitude.ToString());
        return ((Vector2)this.transPosition - (Vector2)pos).magnitude;
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

    public void Update()
    {
        CheckBuildingHP();
    }

    public Building AddBuilding(GameObject tmp, int x_, int y_, Building.BuildingType type)
    {
        Building targetBuilding = new Building();

        targetBuilding.desktop = tmp;
        targetBuilding.transPosition = tmp.transform.position;
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
        foreach (Building item in buildingList)
        {
            double tempDistance = ((Vector2)item.transPosition - (Vector2)pos).magnitude;
            if (distance > tempDistance)
            {
                target = item;
                distance = tempDistance;
            }
        }
        return target;
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

    public int SearchFarm()
    {
        int sum = 0;
        foreach (Building bd in buildingList)
        {
            if (bd.type == Building.BuildingType.FARM)
            {
                sum += bd.desktop.GetComponent<Fieldupgrade>().bonus;
            }
        }
        return sum;
    }

    public void CheckBuildingHP()
    {
        foreach (Building bd in buildingList)
        {
            if (bd.hp <= 0)
            {
                if (bd.type == Building.BuildingType.WIDTHWALL)
                {
                    bd.desktop.GetComponent<Wallupgrade>().Delete();
                }
                else if (bd.type == Building.BuildingType.HEIGHTWALL)
                {
                    bd.desktop.GetComponent<Wallupgrade>().Delete();
                }
                else if (bd.type == Building.BuildingType.TOWER)
                {
                    bd.desktop.GetComponent<Towerupgrade>().Delete();
                }
                else if (bd.type == Building.BuildingType.FARM)
                {
                    bd.desktop.GetComponent<Fieldupgrade>().Delete();
                }
                else if (bd.type == Building.BuildingType.HOME)
                {
                    // 홈에 대해서는 그게 없다!!!! !!
                    // 1!!! !
                }
                break;
            }
        }
    }
}
