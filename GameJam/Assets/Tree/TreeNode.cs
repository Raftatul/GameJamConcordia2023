using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class TreeNode : MonoBehaviour
{
    public enum NodeType
    {
        LEAF,
        ROOT
    }

    public Transform branchs;
    public SpriteRenderer sprite;

    public float minScale;
    public float maxScale;

    public NodeType nodeType = NodeType.LEAF;
    public LineRenderer branchRef;
    public TreeNode nodeParent;
    
    public List<TreeNode> connectedNode;

    public AudioSource pop;
    
    public static int maxNodeConnection = 4;

    public bool isCoreNode;

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
        
        nodeToConnect.sprite.transform.localScale = Vector3.zero;
        float randomValue = Random.Range(minScale, maxScale);
        Vector3 randomScale = new Vector3(randomValue, randomValue, 1);

        nodeToConnect.sprite.transform.DOScale(Vector3.zero, 2).OnComplete(() =>
        {
            nodeToConnect.sprite.transform.DOScale(randomScale, 0.3f).SetEase(Ease.OutBack);
            pop.Play();
        });

        List<Vector3> points = new List<Vector3>();

        float xDifference = transform.position.x - nodeToConnect.transform.position.x;
        float yDifference = transform.position.y - nodeToConnect.transform.position.y;
    
        if (Mathf.Abs(xDifference) > Mathf.Abs(yDifference))
        {
            points.Add(Vector3.zero);
            points.Add(new Vector3(worldPos.x,0));
            points.Add(worldPos);
        }
        else
        {
            points.Add(Vector3.zero);
            points.Add(new Vector3(0,worldPos.y));
            points.Add(worldPos);
        }
        
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
