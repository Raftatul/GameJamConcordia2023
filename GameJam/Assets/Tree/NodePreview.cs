using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NodePreview : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;

    public List<GameObject> nodeInRange;

    public LineRenderer branch;

    public TreeNode nodeObject;
    
    
    void Update()
    {
        switch (nodeObject.nodeType)
        {
            case TreeNode.NodeType.LEAF:
                foreach (var leaf in TreeCore.instance.leafs)
                {
                    float distance = Vector3.Distance(leaf.transform.position, transform.position);
                    if (distance > minDistance && distance < maxDistance)
                    {
                        nodeInRange.Add(leaf);
                    }
                }
                break;
            case TreeNode.NodeType.ROOT:
                foreach (var root in TreeCore.instance.roots)
                {
                     float distance = Vector3.Distance(root.transform.position, transform.position);
                    if (distance > minDistance && distance < maxDistance)
                    {
                        nodeInRange.Add(root);
                    }
                }
                break;
        }

        SetBuildMod(false);

        if (nodeInRange.Count == 0)
        {
            return;
        }

        GameObject closestNode = GetClosestNode(nodeInRange);

        if (!closestNode.GetComponent<TreeNode>().CanLinkToNode())
        {
            return;
        }

        SetBuildMod(true);

        Vector3 worldPos = transform.InverseTransformPoint(closestNode.transform.position);

        if (closestNode.GetComponent<TreeNode>().CanLinkToNode())
        {            
            float xDifference = transform.position.x - closestNode.transform.position.x;
            float yDifference = transform.position.y - closestNode.transform.position.y;
    
            if (Mathf.Abs(xDifference) < Mathf.Abs(yDifference))
            {
                branch.positionCount = 3;
                branch.SetPosition(1, new Vector3(worldPos.x,0));
                branch.SetPosition(2, worldPos);
            }
            else
            {
                branch.positionCount = 3;
                branch.SetPosition(1, new Vector3(0,worldPos.y));
                branch.SetPosition(2, worldPos);
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            BuildLeaf(closestNode);
        }
    }

    private void LateUpdate()
    {
        nodeInRange.Clear();
    }

    public GameObject GetClosestNode(List<GameObject> targetLeaf)
    {
        targetLeaf.Sort((x, y) => Vector2.Distance(x.transform.position, transform.position).CompareTo(Vector2.Distance(y.transform.position, transform.position)));
        
        GameObject closest = targetLeaf[0];
        foreach (var leaf in targetLeaf)
        {
            if (leaf.GetComponent<TreeNode>().GetDistanceToCore() < closest.GetComponent<TreeNode>().GetDistanceToCore())
            {
                if (leaf.GetComponent<TreeNode>().CanLinkToNode())
                {
                    closest = leaf;
                }
            }
        }
        return closest;
    }

    public void SetBuildMod(bool value)
    {
        switch (value)
        {
            case true:
                Color whiteTransparent = Color.white;
                whiteTransparent.a = 0.5f;
                GetComponent<SpriteRenderer>().color = whiteTransparent;
                branch.enabled = true;
                break;
            case false:
                Color redTransparent = Color.red;
                whiteTransparent.a = 0.5f;
                GetComponent<SpriteRenderer>().color = redTransparent;
                branch.enabled = false;
                break;
        }
    }

    public void BuildLeaf(GameObject closestLeaf)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        TreeNode newNode = Instantiate(nodeObject, worldPos, Quaternion.identity);
        newNode.transform.SetParent(closestLeaf.transform);
        closestLeaf.GetComponent<TreeNode>().ConnectToNode(newNode);
    }
}
