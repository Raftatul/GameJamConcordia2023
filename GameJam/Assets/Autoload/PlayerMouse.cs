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

    public BuildMode currentMode;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentMode)
            {
                case BuildMode.ROOT:
                    currentMode = BuildMode.NONE;
                    break;
                case BuildMode.LEAF:
                    currentMode = BuildMode.NONE;
                    break;
                case BuildMode.NONE:
                    currentMode = BuildMode.LEAF;
                    break;
            }
        }
    }
}
