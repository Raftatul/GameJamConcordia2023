using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCore : Leaf
{
    public static TreeCore instance;
    public List<GameObject> leafs;
    public List<GameObject> roots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            leafs.Add(gameObject);
            isCoreLeaf = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
