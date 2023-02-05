using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public GameEvent Wind;
    public GameEvent Rain;
    public GameEvent Cloud;


    [SerializeField] private float rainChance = 50;
    [SerializeField] private float cloudChance = 40;
    [SerializeField] private float WindChance = 40;


    [SerializeField] private bool clouds;
    [SerializeField] private bool rains;

    public GameObject WindEffect;
    public Transform Spawner;


    //private void FixedUpdate()
    //{
    //    if (GlobalVariable.startOfDN)
    //    {
    //        GlobalVariable.startOfDN = false;
    //        GlobalVariable.rain = false;
    //        GlobalVariable.clouds = false;

    //        GlobalVariable.clouds = EventActivatedYN(cloudChance);

    //        if (GlobalVariable.clouds)
    //        {
    //            GlobalVariable.rain = EventActivatedYN(rainChance);
    //        }
    //    }
    //}

    bool EventActivatedYN(float x)
    {
        float y = Random.Range(0, 100);

        if (y <= x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Listener_CheckWeather()
    {
        if (GlobalVariable.startOfDN)
        {
            GlobalVariable.startOfDN = false;
            GlobalVariable.rain = false;
            GlobalVariable.clouds = false;

            GlobalVariable.clouds = EventActivatedYN(cloudChance);
            if (GlobalVariable.clouds)
            {
                Cloud.TriggerEvent();
                WindChance += 20;
            }
            else if (!GlobalVariable.clouds)
            {
                WindChance -= 20;
            }

            if (GlobalVariable.clouds)
            {
                GlobalVariable.rain = EventActivatedYN(rainChance);
                if (GlobalVariable.rain)
                {
                    GlobalVariable.clouds = false;
                    Rain.TriggerEvent();
                }
            }
        }
    }

    void TriggerWind()
    {
        //Transform sp = new Transform(new Vector3(1, 1, 1), Spawner.rotation, Spawner.localScale);
        //float f = Random.Range(100, 1000);
        //Vector3 offset = new Vector3()
        //Instantiate(WindEffect, Spawner.localPosition, Spawner.rotation);
    }

    public void Listener_RainEvent()
    {

    }

    public void Listener_CloudEvent()
    {

    }

    public void Listener_WindEvent()
    {

    }
}
