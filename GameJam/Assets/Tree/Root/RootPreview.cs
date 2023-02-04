using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPreview : MonoBehaviour
{
    public float minDistance;
    public float maxDistance;

    public List<GameObject> rootInRange;

    public LineRenderer branch;

    public GameObject rootObject;
    
    
    void Update()
    {
        foreach (var root in TreeCore.instance.roots)
        {
            if (Vector3.Distance(root.transform.position, transform.position) < maxDistance)
            {
                rootInRange.Add(root);
            }
        }

        SetBuildMod(false);

        if (rootInRange.Count == 0)
        {
            return;
        }

        foreach (var root in rootInRange)
        {
            if (Vector3.Distance(root.transform.position, transform.position) < minDistance)
            {
                return;
            }
        }
        
        GameObject closestRoot = GetClosetsLeaf(rootInRange);

        if (!closestRoot.GetComponent<Root>().CanLinkToRoot())
        {
            return;
        }

        SetBuildMod(true);

        Vector3 worldPos = transform.InverseTransformPoint(closestRoot.transform.position);

        if (closestRoot.GetComponent<Root>().CanLinkToRoot())
        {
            branch.positionCount = 3;
            branch.SetPosition(1, new Vector3(0,worldPos.y));
            branch.SetPosition(2, worldPos);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            BuildRoot(closestRoot);
        }
    }

    private void LateUpdate()
    {
        rootInRange.Clear();
    }

    public GameObject GetClosetsLeaf(List<GameObject> targetLeaf)
    {
        GameObject closets = targetLeaf[0];
        float closestDistance = Vector3.Distance(transform.position, closets.transform.position);
        foreach (var root in targetLeaf)
        {
            if (Vector3.Distance(transform.position, root.transform.position) < closestDistance)
            {
                closets = root;
                closestDistance = Vector3.Distance(transform.position, root.transform.position);
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

    public void BuildRoot(GameObject closestLeaf)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        GameObject new_leaf = Instantiate(rootObject, worldPos, Quaternion.identity);
        closestLeaf.GetComponent<Root>().ConnectRoot(new_leaf);
    }
}
