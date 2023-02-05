using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NodePreview : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;

    public List<TreeNode> nodeInRange;

    public LineRenderer branch;

    public TreeNode nodeObject;

    void Update()
    {
        SetBuildMod(false);
        
        switch (nodeObject.nodeType)
        {
            case TreeNode.NodeType.LEAF:
                foreach (var leaf in TreeCore.instance.leafs)
                {
                    float distance = Vector3.Distance(leaf.transform.position, transform.position);
                    if (distance < maxDistance)
                    {
                        nodeInRange.Add(leaf);
                    }
                }
                break;
            case TreeNode.NodeType.ROOT:
                foreach (var root in TreeCore.instance.roots)
                {
                     float distance = Vector3.Distance(root.transform.position, transform.position);
                    if (distance < maxDistance)
                    {
                        nodeInRange.Add(root);
                    }
                }
                break;
        }
        
        if (nodeInRange.Count == 0)
        {
            return;
        }

        foreach (var node in nodeInRange)
        {
            float distance = Vector3.Distance(node.transform.position, transform.position);
            if (distance < minDistance)
            {
                return;
            }
        }

        TreeNode closestNode = GetClosestNode(nodeInRange);

        if (!closestNode.CanLinkToNode())
        {
            return;
        }

        int distanceCost = (int)Vector2.Distance(transform.position, closestNode.transform.position);
        distanceCost = Mathf.Clamp(distanceCost, 1, 20);
        if (!EnoughResource(distanceCost))
        {
            return;
        }

        SetBuildMod(true);

        Vector3 worldPos = transform.InverseTransformPoint(closestNode.transform.position);

        if (closestNode.CanLinkToNode())
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
            ConsumeResource(distanceCost);
            BuildLeaf(closestNode.gameObject);
        }
    }

    private void LateUpdate()
    {
        nodeInRange.Clear();
    }

    public TreeNode GetClosestNode(List<TreeNode> targetLeaf)
    {
        targetLeaf.Sort((x, y) => Vector2.Distance(x.transform.position, transform.position).CompareTo(Vector2.Distance(y.transform.position, transform.position)));
        return targetLeaf[0];
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

    private bool EnoughResource(float distance)
    {
        foreach (var resource in nodeObject.resourceConsumes)
        {
            switch (resource)
            {
                case TreeNode.ResourceConsume.WATER:
                    if (distance * nodeObject.priceMultiplier >= GlobalVariable.water)
                    {
                        return false;
                    }
                    break;
                case TreeNode.ResourceConsume.AIR:
                    if (distance * nodeObject.priceMultiplier >= GlobalVariable.air)
                    {
                        return false;
                    }
                    break;
                case TreeNode.ResourceConsume.NUTRIMENT:
                    if (distance * nodeObject.priceMultiplier >= GlobalVariable.nutriment)
                    {
                        return false;
                    }
                    break;
                case TreeNode.ResourceConsume.LIGHT:
                    if (distance * nodeObject.priceMultiplier >= GlobalVariable.light)
                    {
                        return false;
                    }
                    break;
            }
        }

        return true;
    }

    private void ConsumeResource(int distance)
    {
        foreach (var resource in nodeObject.resourceConsumes)
        {
            switch (resource)
            {
                case TreeNode.ResourceConsume.WATER:
                    GlobalVariable.water -= distance * nodeObject.priceMultiplier;
                    break;
                case TreeNode.ResourceConsume.AIR:
                    GlobalVariable.air -= distance * nodeObject.priceMultiplier;
                    break;
                case TreeNode.ResourceConsume.NUTRIMENT:
                    GlobalVariable.nutriment -= distance * nodeObject.priceMultiplier;
                    break;
                case TreeNode.ResourceConsume.LIGHT:
                    GlobalVariable.light -= distance * nodeObject.priceMultiplier;
                    break;
            }
        }
    }
}
