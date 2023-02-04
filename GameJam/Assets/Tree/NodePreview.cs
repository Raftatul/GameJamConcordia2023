using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePreview : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;

    public List<GameObject> leafInRange;

    public LineRenderer branch;

    public GameObject leafObject;
    
    
    void Update()
    {
        foreach (var leaf in TreeCore.instance.leafs)
        {
            if (Vector3.Distance(leaf.transform.position, transform.position) < maxDistance)
            {
                leafInRange.Add(leaf);
            }
        }

        SetBuildMod(false);

        if (leafInRange.Count == 0)
        {
            return;
        }

        foreach (var leaf in leafInRange)
        {
            if (Vector3.Distance(leaf.transform.position, transform.position) < minDistance)
            {
                return;
            }
        }
        
        GameObject closestLeaf = GetClosetsLeaf(leafInRange);

        if (!closestLeaf.GetComponent<TreeNode>().CanLinkToNode())
        {
            return;
        }

        SetBuildMod(true);

        Vector3 worldPos = transform.InverseTransformPoint(closestLeaf.transform.position);

        if (closestLeaf.GetComponent<TreeNode>().CanLinkToNode())
        {
            branch.positionCount = 3;
            branch.SetPosition(1, new Vector3(0,worldPos.y));
            branch.SetPosition(2, worldPos);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            BuildLeaf(closestLeaf);
        }
    }

    private void LateUpdate()
    {
        leafInRange.Clear();
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
                    GetComponent<SpriteRenderer>().color = Color.green;
                    branch.enabled = true;
                break;
            case false:
                    GetComponent<SpriteRenderer>().color = Color.red;
                    branch.enabled = false;
                break;
        }
    }

    public void BuildLeaf(GameObject closestLeaf)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        GameObject new_leaf = Instantiate(leafObject, worldPos, Quaternion.identity);
        closestLeaf.GetComponent<TreeNode>().ConnectToNode(new_leaf.GetComponent<TreeNode>());
    }
}
