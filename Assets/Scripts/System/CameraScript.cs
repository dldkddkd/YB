using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private float speed;
    private Vector3 dir;
    public Vector3 vp;
    
	void Start () {
        speed = 8.0f;
        dir = Vector3.zero;
        vp = GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
    }
	
	void Update ()
    {
        vp = GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        dir = Vector3.zero;
        if (vp.x < 0.05f)
        {
            dir += Vector3.left;
        }
        if (vp.x > 0.95f)
        {
            dir += Vector3.right;
        }
        if (vp.y < 0.05f)
        {
            dir += Vector3.down;
        }
        if (vp.y > 0.95f)
        {
            dir += Vector3.up;
        }

        transform.position += speed * dir * Time.deltaTime;
        if (transform.position.x < -7.5f)
        {
            transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, transform.position.z);
        }
        if (transform.position.y > 6.5f)
        {
            transform.position = new Vector3(transform.position.x, 6.5f, transform.position.z);
        }
    }
}
