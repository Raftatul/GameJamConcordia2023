using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceBars : MonoBehaviour
{
    #region Variables

    public Slider slider;
    //public RessourceBars ressourceBar;
    public int maxLevel = 100;
    public int currentLevel;
    
    #endregion

    void Start()
    {
        currentLevel = maxLevel/2;
        SetMaxLevel(maxLevel);
    }

    //void Update()
    //{
    //    //conditions à déterminer pour modifier les niveaux.

    //    if (input.getkeydown(keycode.a))
    //    {
    //        levelchange(globalvariable.nutriment);
    //    }

    //    if (input.getkeydown(keycode.z))
    //    {
    //        levelchange(10);
    //    }
    //}

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

    #endregion 
}
