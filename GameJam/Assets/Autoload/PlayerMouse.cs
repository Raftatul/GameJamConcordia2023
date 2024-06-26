using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public GameObject rootPreview;
    public GameObject leafPreview;

    public enum BuildMode
    {
        ROOT,
        LEAF,
        NONE,
        DESTRUCTION,
        TRANSITION
    }

    public static BuildMode currentMode = BuildMode.NONE;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (currentMode != BuildMode.NONE && currentMode != BuildMode.DESTRUCTION)
        {
            if (mousePos.y < TreeCore.instance.rootCore.transform.position.y)
            {
                currentMode = BuildMode.ROOT;
            }
            else if(mousePos.y > TreeCore.instance.leafCore.transform.position.y)
            {
                currentMode = BuildMode.LEAF;
            }
            else
            {
                currentMode = BuildMode.TRANSITION;
            }
        }
        
        switch (currentMode)
        {
            case BuildMode.ROOT:
                rootPreview.SetActive(true);
                rootPreview.transform.position = mousePos;
                leafPreview.SetActive(false);
                break;
            case BuildMode.LEAF:
                leafPreview.SetActive(true);
                leafPreview.transform.position = mousePos;
                rootPreview.SetActive(false);
                break;
            default:
                leafPreview.SetActive(false);
                rootPreview.SetActive(false);
                break;
        }

        if (Input.GetKeyDown("~"))
        {
            switch (currentMode)
            {
                case BuildMode.ROOT:
                    currentMode = BuildMode.NONE;
                    break;
                case BuildMode.LEAF:
                    currentMode = BuildMode.DESTRUCTION;
                    break;
                case BuildMode.NONE:
                    currentMode = BuildMode.LEAF;
                    break;
                case BuildMode.DESTRUCTION:
                    currentMode = BuildMode.ROOT;
                    break;
            }
        }
    }

    public void SwitchMod(int newState)
    {
        currentMode = (BuildMode)newState;
    }
}
