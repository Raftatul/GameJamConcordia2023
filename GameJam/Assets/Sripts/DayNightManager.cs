using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] bool night;
    public GameEvent TriggerWeather;

    [SerializeField] private Transform moonSun;
    [SerializeField] private int rotateAmount;

    [SerializeField] private float dayTime;
    [SerializeField] private float nightTime;
    private float timer;

    public Color dayColor;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer == dayTime/2) 
        {
            TriggerWeather.TriggerEvent();
        }

        if (timer >= dayTime && GlobalVariable.day)
        {
            MoonSunChange();
        }
        if (timer >= nightTime && !GlobalVariable.day)
        {
            MoonSunChange();
        }
    }

    void MoonSunChange()
    {
        TriggerWeather.TriggerEvent();
        night = GlobalVariable.day;

        GlobalVariable.day = !GlobalVariable.day;
        GlobalVariable.startOfDN = true;
        
        if (rotateAmount < 360)
        {
            rotateAmount += 90;
        }
        else
        {
            rotateAmount = 90;
        }

        moonSun.DORotate(new Vector3(0, rotateAmount, 0), 1).SetEase(Ease.OutBack);

        if (night)
        {
            Camera.main.DOColor(Color.black, 1);
        }
        else
        {
            Camera.main.DOColor(dayColor, 1);
        }
        
        timer = 0;
    }
}
