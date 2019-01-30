using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour {
	public float fade;
	public float time;
	private float timeLimit;
	private bool fadeon;
	private bool flag;
	// Use this for initialization
	void Start () {
		fade = 0.0f;
		time = 0.0f;
		timeLimit = 2.0f;
		flag = false;
		fadeon = false;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            flag = true;
        }
        if (flag) {
			if(time <= timeLimit)
				time += Time.deltaTime;
			if (fadeon)
				fadeon = false;
			else
				fadeon = true;
		}

		if (fadeon & time <= timeLimit) {
			Debug.Log (GetComponent<SpriteRenderer> ().color);
			fade += 0.05f;
			this.GetComponent<SpriteRenderer> ().color = new Color (this.GetComponent<SpriteRenderer> ().color.r,
					this.GetComponent<SpriteRenderer> ().color.g,
					this.GetComponent<SpriteRenderer> ().color.b, fade);		
		}
		else if (!fadeon & time > timeLimit & time <= timeLimit * 2) {
			Debug.Log ("페이드인");
			time -= Time.deltaTime;
			fade -= 0.05f;
			this.GetComponent<SpriteRenderer> ().color = new Color (this.GetComponent<SpriteRenderer> ().color.r,
					this.GetComponent<SpriteRenderer> ().color.g,
					this.GetComponent<SpriteRenderer> ().color.b, fade);		
		}
	}
}
