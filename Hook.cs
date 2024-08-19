using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    // Start is called before the first frame update

    public LineRenderer rope;
    public Transform circle;

    Rotate pulley;

    void Start()
    {
        pulley = GameObject.Find("pulley").GetComponent<Rotate>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fish")
        {
            if (!pulley.come_back)
            {
                    
                    pulley.score += other.gameObject.GetComponent<Fish>().score;

                    if (other.gameObject.GetComponent<Fish>().isTreasure)
                    {
                       pulley.treasure++; 
                    }

                    pulley.come_back = true;
                    float come_back_speed = other.gameObject.GetComponent<Fish>().come_back_speed;
                    pulley.come_back_speed = pulley.empty_speed - (2 * come_back_speed);
                    if (pulley.come_back_speed <= 0)
                    {
                        pulley.come_back_speed = 5.0f;
                    }
                    other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    if (transform.childCount == 0)
                    {
                        other.gameObject.transform.parent = transform;
                        other.gameObject.GetComponent<FishMove>().moveSpeed = 0.0f;
                    } 
            }
        }
        else if (other.gameObject.tag == "border")
        {
            pulley.come_back = true;
            pulley.shoot = false;
        }
    }
    void Update()
    {
        draw_line();
    }

    void draw_line()
    {
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, circle.position);
    }
}
