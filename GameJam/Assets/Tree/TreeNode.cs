using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using DG.Tweening;

public class TreeNode : MonoBehaviour
{
    public enum NodeType
    {
        LEAF,
        ROOT
    }

    public NodeType nodeType = NodeType.LEAF;
    public LineRenderer branchRef;
    public TreeNode nodeParent;
    
    public List<TreeNode> connectedNode;

    public AudioSource pop;
    
    public static int maxNodeConnection = 3;

    public bool isCoreNode;

    private void Start()
    {
        if (isCoreNode)
        {
            TreeCore.instance.leafs.Add(gameObject);
            TreeCore.instance.roots.Add(gameObject);
            return;
        }
        switch (nodeType)
        {
            case NodeType.LEAF:
                TreeCore.instance.leafs.Add(gameObject);
                break;
            case NodeType.ROOT:
                TreeCore.instance.roots.Add(gameObject);
                break;
        }
    }

    public void ConnectToNode(TreeNode nodeToConnect)
    {
        nodeToConnect.nodeParent = this;
        connectedNode.Add(nodeToConnect);
        
        LineRenderer newBranch = Instantiate(branchRef, transform.position, Quaternion.identity);
        Vector3 worldPos = transform.InverseTransformPoint(nodeToConnect.transform.position);
        newBranch.transform.SetParent(transform);

        nodeToConnect.GetComponent<SpriteRenderer>().enabled = false;

        nodeToConnect.transform.DOScale(Vector3.one, 2).OnComplete(() =>
        {
            nodeToConnect.transform.localScale = Vector3.zero;
            nodeToConnect.GetComponent<SpriteRenderer>().enabled = true;
            nodeToConnect.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
            pop.Play();
        });

        List<Vector3> points = new List<Vector3>();
        points.Add(Vector3.zero);
        points.Add(new Vector3(worldPos.x,0));
        points.Add(worldPos);

        newBranch.GetComponent<Branch>().Grow(points.ToArray());
    }
    
    public bool CanLinkToNode()
    {
        return connectedNode.Count < maxNodeConnection;
    }

    public int GetDistanceToCore()
    {
        if (nodeParent.isCoreNode)
        {
            return 1;
        }
        return 1 + nodeParent.GetDistanceToCore();
    }
}
