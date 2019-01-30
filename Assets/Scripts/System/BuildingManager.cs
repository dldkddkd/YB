using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    private int mapSizeX = 32;
    private int mapSizeY = 24;

    public enum BuildingType
    {
        NONE, HOME, WIDTHWALL, HEIGHTWALL, TOWER
    };

    public Vector2 pos
    {
        get {
            return pos;
        }

        set
        {
            if (value.x < 0 || mapSizeX <= value.x
                || value.y < 0 || mapSizeY <= value.y )
            {
                return;
            }
            else
            {
                this.pos = value;
            }
        }
    }

    public int xSize
    {
        get
        {
            return xSize;
        }
        set
        {
            if (value <= 0
                || mapSizeX <= xSize)
            {
                return;
            }
            else
            {
                this.xSize = value;
            }
        }
    }

    public int ySize
    {
        get
        {
            return ySize;
        }
        set
        {
            if (value <= 0
                || mapSizeY <= ySize)
            {
                return;
            }
            else
            {
                this.ySize = value;
            }
        }
    }

    public BuildingType type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;    
        }
    }


}

public class BuildingManager : MonoBehaviour {

    private List<Building> buildingList = new List<Building>();

    public void AddBuilding(int x_, int y_, Building.BuildingType type, int xS, int yS)
    {
        Building targetBuilding = new Building();
        targetBuilding.pos = new Vector2(x_, y_);
        targetBuilding.xSize = xS;
        targetBuilding.ySize = yS;
        targetBuilding.type = type;

        buildingList.Add(targetBuilding);
    }

    public Building.BuildingType IsExistBuilding(Vector2 pos)
    {
        Building target = null;
        foreach (Building item in buildingList)
        {
            if (item.pos == pos)
            {
                return item.type;
            }
        }
        return Building.BuildingType.NONE;
    }

}
