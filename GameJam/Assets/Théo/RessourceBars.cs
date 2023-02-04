using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceBars : MonoBehaviour
{
    #region Variables

    public Slider slider;
    public RessourceBars ressourceBar;
    public int maxLevel = 100;
    public int currentLevel;

    //public enum Type
    //{
    //    water,
    //    light,
    //    nutriment,
    //    air
    //}

    //public Type ressourceType;
    
    #endregion

    void Start()
    {
        currentLevel = maxLevel/2;
        SetMaxLevel(maxLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LevelChange(GlobalVariable.nutriment);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            LevelChange(10);
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
        currentLevel = Mathf.Clamp(currentLevel, 0, 100);
        SetLevel(currentLevel);
    }

    //void SetGlobalVar(int globalVar, int multip)
    //{
    //    globalVar = Mathf.Clamp(globalVar, 0, 100);
    //    globalVar += multip*10;
    //}
    #endregion 
}
