using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreeCore : MonoBehaviour
{
    public static TreeCore instance;
    
    public List<TreeNode> leafs;
    public List<TreeNode> roots;

    public TreeNode leafCore;
    public TreeNode rootCore;

    public int maxLeafCount = 5;

    int i = 0;
    int t = 5;

    public UnityEvent newNode;

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
        
        leafs.Add(leafCore);
        roots.Add(rootCore);
    }

    public void AddNewLeaf(TreeNode newLeaf)
    {
        leafs.Add(newLeaf);
        newNode.Invoke();
    }
    
    public void AddNewRoot(TreeNode newRoot)
    {
        roots.Add(newRoot);
        newNode.Invoke();
    }
}
