using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] private Transform moonSun;

    [SerializeField] private float dayTime;
    [SerializeField] private float nightTime;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= dayTime && GlobalVariable.day)
        {
            GlobalVariable.day = !GlobalVariable.day;
            MoonSunChange();
            timer = 0;
        }
        if (timer >= nightTime && !GlobalVariable.day)
        {
            GlobalVariable.day = !GlobalVariable.day;
            MoonSunChange();
            timer = 0;
        }
    }

    void MoonSunChange()
    {
        if (GlobalVariable.day)
        {
            moonSun.DORotate(new Vector3(0, 90, 0), 1).SetEase(Ease.OutBack);
        }
        if (!GlobalVariable.day)
        {
            moonSun.DORotate(new Vector3(0, 0, 0), 1).SetEase(Ease.OutBack);
        }
    }
}
