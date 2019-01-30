using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScr : MonoBehaviour {

    public GameObject[,] Map;
    private GameObject Tile;

	void Start () {
        Map = new GameObject[32, 24];
        Tile = Resources.Load("tile") as GameObject;
        for (int i = 0; i < 32; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                Map[i, j] = Instantiate(Tile, new Vector3(-15 + i, 12 - j, 100), Quaternion.Euler(0, 0, 0));
                Map[i, j].transform.SetParent(GameObject.Find("tiles").transform);
                Map[i, j].GetComponent<Tiles>().able = true;
            }
        }
        Map[15, 11].GetComponent<Tiles>().able = false;
        Map[15, 12].GetComponent<Tiles>().able = false;
        Map[16, 11].GetComponent<Tiles>().able = false;
        Map[16, 12].GetComponent<Tiles>().able = false;
    }
	
	void Update () {
		
	}
}
