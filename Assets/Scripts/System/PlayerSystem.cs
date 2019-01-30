using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    private GameObject fairy;
    private GameObject scv;
    public bool ab1, ab2;
    public int money, maxphp, atk;

	void Start () {
        fairy = Resources.Load("Fairy") as GameObject;
        scv = Instantiate(fairy, new Vector3(2, 0, 0), Quaternion.Euler(0, 0, 0));
        scv.transform.SetParent(gameObject.transform);
        ab1 = false;
        ab2 = false;
        money = 600;
        maxphp = 100;
        atk = 10;
        scv.GetComponent<PlayerMove>().maxphp = maxphp;
        scv.GetComponent<PlayerMove>().php = maxphp;
        scv.GetComponent<PlayerMove>().atk = atk;
    }
	
	void Update ()
    {
    }

    IEnumerator Death()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);
            scv = Instantiate(fairy, new Vector3(2, 0, 0), Quaternion.Euler(0, 0, 0));
            scv.transform.SetParent(gameObject.transform);
            scv.GetComponent<PlayerMove>().maxphp = maxphp;
            scv.GetComponent<PlayerMove>().php = maxphp;
            scv.GetComponent<PlayerMove>().atk = atk;
        }
    }

    public void Ability1Up()
    {
        if (money >= 300 && ab1 == false)
        {
            money -= 300;
            ab1 = true;
            GameObject.Find("UIs").GetComponent<UIManager>().ab1 = true;
        }
    }
    public void Ability2Up()
    {
        if (money >= 200 && ab2 == false)
        {
            money -= 200;
            ab2 = true;
            GameObject.Find("UIs").GetComponent<UIManager>().ab2 = true;
        }
    }
    public void Ability3Up()
    {
        if (money >= 100)
        {
            money -= 100;
            maxphp += 20;
            scv.GetComponent<PlayerMove>().maxphp = maxphp;
        }
    }
    public void Ability4Up()
    {
        if (money >= 100)
        {
            money -= 100;
            atk += 10;
            scv.GetComponent<PlayerMove>().atk = atk;
        }
    }
}
