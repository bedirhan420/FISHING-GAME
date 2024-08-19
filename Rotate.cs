using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public bool right = true;
    public bool left = false;
    public bool stop = false;
    public bool shoot = false;
    public bool hasTreasuer = false;

    public bool isShootable = true;
    public bool come_back = false;

    public Transform hook;

    public float shoot_speed = 500.0f;
    public float empty_speed = 675.0f;
    public float come_back_speed = 0.0f;
    public float rotation_speed = 15.0f;
    private int controler;
    public int score = 0;
    public int treasure = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!stop)
        {
            if (Mathf.Abs(transform.rotation.eulerAngles.z - 70) < 5f || Mathf.Abs(transform.rotation.eulerAngles.z - 290) < 5f)
            {
                controler++;
            }
            if (controler % 2 == 1)
            {
                right = false;
                left = true;
            }
            if (controler % 2 == 0)
            {
                right = true;
                left = false;
            }
            if (right)
            {
                transform.Rotate(Vector3.forward * rotation_speed * Time.deltaTime);
            }
            if (left)
            {
                transform.Rotate(Vector3.back * rotation_speed * Time.deltaTime);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!shoot && isShootable)
            {
                right = false;
                left = false;
                stop = true;
                shoot = true;
                hook.parent = null;
            }
        }

        if (shoot)
        {
            hook.gameObject.GetComponent<Rigidbody2D>().velocity = -transform.up * Time.deltaTime * shoot_speed;

        }
        if (come_back)
        {
            hook.gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * Time.deltaTime * come_back_speed;

        }
        if (hasTreasuer)
        {
            if (score >= gameObject.GetComponent<ManagerTreausure>().target_score && treasure == 1)
            {
                Debug.Log("You win");
                stop = true;
                gameObject.GetComponent<ManagerTreausure>().time = 0;
            }
        }
        else
        {
            if (score >= gameObject.GetComponent<Manager>().target_score)
            {
                Debug.Log("You win");
                stop = true;
                gameObject.GetComponent<Manager>().time = 0;
            }
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "hook")
        {
            stop = false;
            shoot = false;
            come_back = false;
            right = true;
            left = false;
            hook.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            hook.parent = transform;
            if (hook.childCount > 0)
            {
                Destroy(hook.GetChild(0).gameObject);
                Debug.Log("score:" + score);
            }
            come_back_speed = empty_speed;
        }
    }
}
