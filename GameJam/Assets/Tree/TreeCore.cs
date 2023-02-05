using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCore : MonoBehaviour
{
    public static TreeCore instance;
    
    public List<GameObject> leafs;
    public List<GameObject> roots;

    public TreeNode leafCore;
    public TreeNode rootCore;

    public int maxLeafCount = 5;

    int i = 0;
    int t = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CameraHandler()
    {
        i++;

        if (i == t)
        {
            Camera.main.GetComponent<OrthographicZoom>().ZoomOut();
            i = 0;
            //t++;
        }
    }
}
