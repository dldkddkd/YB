using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateManager : MonoBehaviour {
    
    private GameObject ps;

	public Slider HPSlider;
	public Slider PowderSlider;
    public Text HPText;
    public Text PowderText;

    void Start () {
        ps = GameObject.Find("Player");
	}
	
	void Update () {
        if (ps.transform.GetChild(0) != null)
        {
            HPSlider.value = ps.transform.GetChild(0).GetComponent<PlayerMove>().php;
        }
        else
        {
            HPSlider.value = 0;
        }
        PowderSlider.value = ps.GetComponent<PlayerSystem>().money;
        HPText.text = HPSlider.value + " / 100";
        PowderText.text = PowderSlider.value + " / 2000";
    }
}
