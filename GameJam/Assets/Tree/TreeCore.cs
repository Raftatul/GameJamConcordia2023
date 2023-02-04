using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCore : MonoBehaviour
{
    public static TreeCore instance;
    
    public List<GameObject> leafs;
    public List<GameObject> roots;

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

    private void Update()
    {
        if (leafs.Count >= 5)
        {
            for (int i = 0; i < leafs.Count; i++)
            {
                Destroy(leafs[i]);
            }
            leafs.Clear();

            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
