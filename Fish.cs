using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    public float come_back_speed=50.0f;
    public int score=1;
    public bool isYellow=true;
    public bool isGreen=false;
    public bool isOrange=false;
    public bool isJellyFish=false;
    public bool isWhale=false;
    public bool isShark=false;
    public bool isBabyShark=false;
    public bool isVatos=false;
    public bool isLightning=false;
    public bool isTreasure=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isYellow)
        {
            score=1;
            come_back_speed=20.0f;
        }
        if (isGreen)
        {
            score=2;
            come_back_speed=25.0f;
        }
        if (isOrange)
        {
            score=4;
            come_back_speed=30.0f;
        }
        if (isJellyFish)
        {
            score=-2;
            come_back_speed=15.0f;
        }
         if (isWhale)
        {
            score=6;
            come_back_speed=50.0f;
        }
         if (isShark)
        {
            score=10;
            come_back_speed=53.0f;
        }
         if (isVatos)
        {
            score=3;
            come_back_speed=22.0f;
        }
          if (isLightning)
        {
            score=-6;
            come_back_speed=30.0f;
        }
         if (isBabyShark)
        {
            score=5;
            come_back_speed=35.0f;
        } 
         if (isTreasure)
        {   
            score=0;
            come_back_speed=35.0f;
        }

    }
}
