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

    public Transform branchs;
    public SpriteRenderer sprite;

    public NodeType nodeType = NodeType.LEAF;
    public LineRenderer branchRef;
    public TreeNode nodeParent;
    
    public List<TreeNode> connectedNode;

    public AudioSource pop;
    
    public static int maxNodeConnection = 3;

    public bool isCoreNode;

    public int maxDistanceToCore = 4;

    private void Start()
    {
        switch (nodeType)
        {
            case NodeType.LEAF:
                TreeCore.instance.leafs.Add(gameObject);
                TreeCore.instance.CameraHandler();
                break;
            case NodeType.ROOT:
                TreeCore.instance.roots.Add(gameObject);
                TreeCore.instance.CameraHandler();
                break;
        }
    }

    public void ConnectToNode(TreeNode nodeToConnect)
    {
        nodeToConnect.nodeParent = this;
        connectedNode.Add(nodeToConnect);
        
        LineRenderer newBranch = Instantiate(branchRef, transform.position, Quaternion.identity);
        Vector3 worldPos = transform.InverseTransformPoint(nodeToConnect.transform.position);
        newBranch.transform.SetParent(branchs);

        nodeToConnect.sprite.enabled = false;
        nodeToConnect.sprite.transform.localScale -= new Vector3(nodeToConnect.GetDistanceToCore(), nodeToConnect.GetDistanceToCore(), 0) * 0.25f;

        nodeToConnect.transform.DOScale(Vector3.one, 2).OnComplete(() =>
        {
            nodeToConnect.transform.localScale = Vector3.zero;
            nodeToConnect.sprite.enabled = true;
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
        if (isCoreNode)
        {
            return 0;
        }
        if (nodeParent.isCoreNode)
        {
            return 1;
        }
        return 1 + nodeParent.GetDistanceToCore();
    }

    public void ClearBranchs()
    {
        foreach (Transform child in branchs.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
