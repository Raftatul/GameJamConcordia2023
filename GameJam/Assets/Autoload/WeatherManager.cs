using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private float rainChance = 50;
    [SerializeField] private float cloudChance = 40;


    private void FixedUpdate()
    {
        if (GlobalVariable.startOfDN)
        {
            GlobalVariable.startOfDN = false;
            GlobalVariable.rain = false;
            GlobalVariable.clouds = false;
            
            GlobalVariable.clouds = EventActivatedYN(cloudChance);
            
            if (GlobalVariable.clouds)
            {
                GlobalVariable.rain = EventActivatedYN(rainChance);
            }
        }
    }

    bool EventActivatedYN(float x)
    {
        float y = Random.Range(0,100);

        if (y<=x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
