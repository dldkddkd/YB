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
    public Text AtkText;

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
        HPSlider.maxValue = ps.GetComponent<PlayerSystem>().maxphp;
        HPText.text = HPSlider.value + " / " + HPSlider.maxValue;
        PowderText.text = PowderSlider.value + " / 2000";
        AtkText.text = "Atk: " + ps.GetComponent<PlayerSystem>().atk;
    }
}
