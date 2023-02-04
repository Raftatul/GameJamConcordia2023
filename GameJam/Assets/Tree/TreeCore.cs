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

    private void Update()
    {
        if (leafs.Count > maxLeafCount)
        {
            maxLeafCount += 5;
            for (int i = 0; i < leafs.Count; i++)
            {
                if (!leafs[i].GetComponent<TreeNode>().isCoreNode)
                {
                    Destroy(leafs[i]);
                }
            }
            leafs.Clear();
            leafs.Add(leafCore.gameObject);
            leafCore.ClearBranchs();
            leafCore.connectedNode.Clear();

            leafCore.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
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
