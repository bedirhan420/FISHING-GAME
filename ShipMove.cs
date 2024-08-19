using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 3.0f;
    private bool movingRight = true;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight && transform.position.x >= 6)
        {
            transform.localScale = new Vector3(-3.5f, 9.7f, 1);
            movingRight = false;

        }
        else if (!movingRight && transform.position.x <= -6)
        {
            movingRight = true;

            transform.localScale = new Vector3(3.5f, 9.7f, 1);
        }


        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
