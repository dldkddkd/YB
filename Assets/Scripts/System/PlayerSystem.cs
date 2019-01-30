using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem : MonoBehaviour {

    private GameObject fairy;
    private GameObject scv;
    public int money;

	void Start () {
        fairy = Resources.Load("Fairy") as GameObject;
        scv = Instantiate(fairy, new Vector3(2, 0, 0), Quaternion.Euler(0, 0, 0));
        scv.transform.SetParent(gameObject.transform);
        money = 600;
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
        }
    }
}
