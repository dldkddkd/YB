using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StateManager : MonoBehaviour {
	public int HP;
	public int powder;
	public Slider HPSlider;
	public Slider PowderSlider;
	// Use this for initialization
	void Start () {
		HP = 100;
		powder = 600;
	}
	
	// Update is called once per frame
	void Update () {
		HPSlider.value = HP;
		PowderSlider.value = powder;
	}
}
