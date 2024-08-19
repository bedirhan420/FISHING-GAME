using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3.0f;
    private bool movingRight = true;
    private bool movingUp = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Fish>().isJellyFish)
        {
            if (movingRight && transform.position.x >= 8)
            {
                movingRight = false;
                if (gameObject.GetComponent<Fish>().isOrange)
                {
                    transform.localScale = new Vector3(-12, 12, 1);
                }
                else if (gameObject.GetComponent<Fish>().isVatos|| gameObject.GetComponent<Fish>().isLightning)
                {
                    transform.localScale = new Vector3(-5, 5, 1);
                }
                else
                {
                    transform.localScale = new Vector3(-10, 10, 1);
                }
            }
            else if (!movingRight && transform.position.x <= -8)
            {
                movingRight = true;
                if (gameObject.GetComponent<Fish>().isOrange)
                {
                    transform.localScale = new Vector3(12, 12, 1);
                }
                else if (gameObject.GetComponent<Fish>().isVatos || gameObject.GetComponent<Fish>().isLightning )
                {
                    transform.localScale = new Vector3(5, 5, 1);
                }
                else
                {
                    transform.localScale = new Vector3(10, 10, 1);
                }

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
        else
        {
            if (movingUp && transform.position.y >= 2)
            {
                movingUp = false;


                // transform.localScale = new Vector3(10, -10, 1);

            }
            else if (!movingUp && transform.position.y <= -4)
            {
                movingUp = true;


                transform.localScale = new Vector3(10, 10, 1);


            }


            if (movingUp)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            }
        }

    }
}
