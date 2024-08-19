using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text time_txt;
    public Text score_txt;

    public Text target_score_txt;


    public int time;
    public int target_score;
    public int score = 0;
    public int treasure = 0;


    void Start()
    {
        target_score_txt.text = "TARGET SCORE:" + target_score.ToString();
        InvokeRepeating("time_reduce", 0, 1.0f);
    }

    // Update is called once per frame
    void time_reduce()
    {
        if (time > 0)
        {
            time--;
        }

        time_txt.text = "TIME:" + time.ToString();
        if (time <= 0)
        {
            gameObject.GetComponent<Rotate>().isShootable = false;
            if (score < target_score)
            {
                Debug.Log("you lose");
            }

            gameObject.GetComponent<Rotate>().stop = true;
        }
        if (score < 0)
        {
            time = 0;
            Debug.Log("you lose");
        }
    }
    void Update()
    {
        score = gameObject.GetComponent<Rotate>().score;
        score_txt.text = "SCORE:" + score;

    }
}
