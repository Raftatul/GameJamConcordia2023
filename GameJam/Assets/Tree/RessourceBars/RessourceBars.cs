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
    
    #endregion

    void Start()
    {
        currentLevel = maxLevel/2;
        SetMaxLevel(maxLevel);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) == true) && (ressourceBar.currentLevel > 0))
        {
            ressourceBar.LevelChange(-10);
        }

        if ((Input.GetKeyDown(KeyCode.Z) == true) && (ressourceBar.currentLevel < 100))
        {
            ressourceBar.LevelChange(10);
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
        SetLevel(currentLevel);
    }

    #endregion 
}
