using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTimer
{
    public bool timerIsOn = true;
    float timer = 0;
    
    public string Timer(float maxTimer)
    {
        if(timerIsOn)
        {
            if(timer >= maxTimer)
            {
                timer = 0;
                return "complete";
            }
            else
            {
                timer += Time.deltaTime;
                return "incomplete";
            }   
        }
        else
        {
            return "inactive";
        }
    }
}
