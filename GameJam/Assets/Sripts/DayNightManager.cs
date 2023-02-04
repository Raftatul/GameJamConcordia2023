using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DayNightManager : MonoBehaviour
{
    public GameEvent YourEvent;
        
    [SerializeField] private Transform moonSun;

    [SerializeField] private float dayTime;
    [SerializeField] private float nightTime;
    private float timer;

    private void Start()
    {
        YourEvent.TriggerEvent();
        
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
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
        GlobalVariable.day = !GlobalVariable.day;
        GlobalVariable.startOfDN = true;

        if (GlobalVariable.day)
        {
            moonSun.DORotate(new Vector3(0, 90, 0), 1).SetEase(Ease.OutBack);
        }
        if (!GlobalVariable.day)
        {
            moonSun.DORotate(new Vector3(0, 0, 0), 1).SetEase(Ease.OutBack);
        }
        timer = 0;
    }
}
