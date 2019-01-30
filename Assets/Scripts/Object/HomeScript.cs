using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{

    public int hp;
    public float x;
    public GameObject GB, WB, UIM;

    void Start()
    {
        hp = 5000;
        x = (5000 - hp) / 1.772f;
        UIM = GameObject.Find("UIs");
        GB = GameObject.Find("GreenBar");
        WB = GameObject.Find("WhiteBar");
        GB.gameObject.SetActive(false);
        WB.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            hp -= 1;
        }
        GB.transform.position = new Vector3(0.042f - ((5000 - hp) * 1.792f) / 5000.0f + 0.5f, 1.782f + 0.5f, 5.0f);
        GB.transform.localScale = new Vector3(0.42f * hp / 5000.0f, 0.042f, 1.0f);
    }

    private void OnMouseDown()
    {
        GB.gameObject.SetActive(true);
        WB.gameObject.SetActive(true);
        UIM.GetComponent<UIManager>().BuildSelect = true;
        UIM.GetComponent<UIManager>().Upgrading = false;
        UIM.GetComponent<UIManager>().ability = false;
    }
}
