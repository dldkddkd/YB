using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    private GameObject fairy;
    private GameObject scv;
    public int money, maxphp, atk;

	void Start () {
        fairy = Resources.Load("Fairy") as GameObject;
        scv = Instantiate(fairy, new Vector3(2, 0, 0), Quaternion.Euler(0, 0, 0));
        scv.transform.SetParent(gameObject.transform);
        money = 600;
        maxphp = 100;
        atk = 1;
        scv.GetComponent<PlayerMove>().maxphp = maxphp;
        scv.GetComponent<PlayerMove>().php = maxphp;
        scv.GetComponent<PlayerMove>().atk = atk;
    }
	
	void Update () {
		
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
        //stage...
    }
    public void Ability2Up()
    {

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
