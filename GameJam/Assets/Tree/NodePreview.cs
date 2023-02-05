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
                    if (Vector3.Distance(leaf.transform.position, transform.position) < maxDistance)
                    {
                        nodeInRange.Add(leaf);
                    }
                }
                break;
            case TreeNode.NodeType.ROOT:
                foreach (var leaf in TreeCore.instance.roots)
                {
                    if (Vector3.Distance(leaf.transform.position, transform.position) < maxDistance)
                    {
                        nodeInRange.Add(leaf);
                    }
                }
                break;
        }

        SetBuildMod(false);

        if (nodeInRange.Count == 0)
        {
            return;
        }

        foreach (var node in nodeInRange)
        {
            if (Vector3.Distance(node.transform.position, transform.position) < minDistance)
            {
                return;
            }
        }
        
        GameObject closestLeaf = GetClosetsLeaf(nodeInRange);

        if (!closestLeaf.GetComponent<TreeNode>().CanLinkToNode())
        {
            return;
        }

        SetBuildMod(true);

        Vector3 worldPos = transform.InverseTransformPoint(closestLeaf.transform.position);

        if (closestLeaf.GetComponent<TreeNode>().CanLinkToNode())
        {
            branch.positionCount = 3;
            branch.SetPosition(1, new Vector3(worldPos.x,0));
            branch.SetPosition(2, worldPos);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            BuildLeaf(closestLeaf);
        }
    }

    private void LateUpdate()
    {
        nodeInRange.Clear();
    }

    public GameObject GetClosetsLeaf(List<GameObject> targetLeaf)
    {
        GameObject closets = targetLeaf[0];
        float closestDistance = Vector3.Distance(transform.position, closets.transform.position);
        foreach (var leaf in targetLeaf)
        {
            if (Vector3.Distance(transform.position, leaf.transform.position) < closestDistance)
            {
                closets = leaf;
                closestDistance = Vector3.Distance(transform.position, leaf.transform.position);
            }
        }

        return closets;
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
        closestLeaf.GetComponent<TreeNode>().ConnectToNode(newNode);
    }
}
