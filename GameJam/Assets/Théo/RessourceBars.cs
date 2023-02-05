using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceBars : MonoBehaviour
{
    #region Variables

    public enum ResourceTargets
    {
        WATER,
        AIR,
        NUTRIMENT,
        LIGHT
    }

    public ResourceTargets resourceTarget;

    public Slider slider;
    //public RessourceBars ressourceBar;
    private int maxLevel = 50;
    public int currentLevel;
    
    #endregion

    void Start()
    {
        currentLevel = maxLevel/2;
        SetMaxLevel(maxLevel);
    }

    void Update()
    {
        switch (resourceTarget)
        {
            case ResourceTargets.WATER:
                SetLevel(GlobalVariable.water);
                break;
            case ResourceTargets.AIR:
                SetLevel(GlobalVariable.air);
                break;
            case ResourceTargets.NUTRIMENT:
                SetLevel(GlobalVariable.nutriment);
                break;
            case ResourceTargets.LIGHT:
                SetLevel(GlobalVariable.light);
                break;
        }
    }

    #region Methods

    public void SetMaxLevel(int maxLevelParam)
    {
        slider.maxValue = maxLevelParam;
    }

    public void SetLevel(int levelParam)
    {
        slider.value = levelParam;
    }

    void LevelChange(int damage)
    {
        currentLevel += damage;
        currentLevel = Mathf.Clamp(currentLevel, 0, 300);
        SetLevel(currentLevel);
    }

    #endregion 
}
