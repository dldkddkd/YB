using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private bool u, d, l, r;
    private int wall;
    private float speed;
    private Vector3 dir;

	void Start () {
        u = true;
        d = true;
        l = true;
        r = true;
        wall = 0;
        speed = 5.0f;
        dir = Vector3.zero;
	}

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 5 + transform.position.y);
        dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W) && u == true)
        {
            dir += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A) && l == true)
        {
            dir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S) && d == true)
        {
            dir += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D) && r == true)
        {
            dir += Vector3.right;
        }

        if (dir.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (dir.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.position += speed * dir * Time.deltaTime;
        if (transform.position.x <= -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= 16)
        {
            transform.position = new Vector3(16, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= -11)
        {
            transform.position = new Vector3(transform.position.x, -11, transform.position.z);
        }
        if (transform.position.y >= 12)
        {
            transform.position = new Vector3(transform.position.x, 12, transform.position.z);
        }

        if (wall == 0)
        {
            u = true;
            d = true;
            l = true;
            r = true;
        }
	}
    
    private void OnMouseDown()
    {
        GameObject.Find("UIs").GetComponent<UIManager>().BuildSelect = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            wall += 1;
            Vector3 angle = other.transform.position - transform.position;
            float angledeg = Mathf.Acos(Mathf.Abs(angle.x) / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y)) * Mathf.Rad2Deg;
            float theta = Mathf.Atan((other.transform.localScale.y * other.GetComponent<BoxCollider2D>().size.y) / (other.transform.localScale.x * other.GetComponent<BoxCollider2D>().size.x)) * Mathf.Rad2Deg;

            if (angledeg >= theta && other.transform.position.y > transform.position.y) //upside
            {
                u = false;
            }
            if (angledeg >= theta && other.transform.position.y < transform.position.y) //downside
            {
                d = false;
            }
            if (angledeg <= theta && other.transform.position.x > transform.position.x) //leftside
            {
                r = false;
            }
            if (angledeg <= theta && other.transform.position.x < transform.position.x) //rightside
            {
                l = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            if (wall == 1)
            {
                Vector3 angle = other.transform.position - transform.position;
                float angledeg = Mathf.Acos(Mathf.Abs(angle.x) / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y)) * Mathf.Rad2Deg;
                float theta = Mathf.Atan((other.transform.localScale.y * other.GetComponent<BoxCollider2D>().size.y) / (other.transform.localScale.x * other.GetComponent<BoxCollider2D>().size.x)) * Mathf.Rad2Deg;
                //Debug.Log(theta + " " + angledeg);
                if (!(angledeg >= theta - 1 && other.transform.position.y > transform.position.y)) //upside
                {
                    u = true;
                }
                if (!(angledeg >= theta - 1 && other.transform.position.y < transform.position.y)) //downside
                {
                    d = true;
                }
                if (!(angledeg <= theta && other.transform.position.x > transform.position.x)) //leftside
                {
                    r = true;
                }
                if (!(angledeg <= theta && other.transform.position.x < transform.position.x)) //rightside
                {
                    l = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            wall -= 1;
            if (wall == 0)
            {
                Vector3 angle = other.transform.position - transform.position;
                float angledeg = Mathf.Acos(Mathf.Abs(angle.x) / Mathf.Sqrt(angle.x * angle.x + angle.y * angle.y)) * Mathf.Rad2Deg;
                float theta = Mathf.Atan((other.transform.localScale.y * other.GetComponent<BoxCollider2D>().size.y) / (other.transform.localScale.x * other.GetComponent<BoxCollider2D>().size.x)) * Mathf.Rad2Deg;

                if (angledeg >= theta - 1 && other.transform.position.y > transform.position.y) //upside
                {
                    u = true;
                }
                if (angledeg >= theta - 1 && other.transform.position.y < transform.position.y) //downside
                {
                    d = true;
                }
                if (angledeg <= theta + 50 && other.transform.position.x > transform.position.x) //leftside
                {
                    r = true;
                }
                if (angledeg <= theta + 50 && other.transform.position.x < transform.position.x) //rightside
                {
                    l = true;
                }
            }
        }
    }
}
