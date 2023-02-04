using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public static int maxLeafConnection = 3;
    
    public LineRenderer branchRef;
    public List<GameObject> connectedLeaf;

    public Leaf leafParent;
    
    public bool isCoreLeaf;


    private void Awake()
    {
        TreeCore.instance.leafs.Add(gameObject);
    }

    public void ConnectLeaf(GameObject newLeaf)
    {
        if (newLeaf.GetComponent<Leaf>())
        {
            newLeaf.GetComponent<Leaf>().leafParent = this;
        }
        connectedLeaf.Add(newLeaf);
        LineRenderer newBranch = Instantiate(branchRef, transform.position, Quaternion.identity);
        Vector3 worldPos = transform.InverseTransformPoint(newLeaf.transform.position);
        newBranch.transform.SetParent(transform);

        newBranch.SetPosition(0, Vector3.zero);
        newBranch.positionCount = 3;
        newBranch.SetPosition(1, new Vector3(worldPos.x,0));
        newBranch.SetPosition(2, worldPos);
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        
        if (hit.collider != null)
        {
            print(hit.collider);
        }

        if (GlobalVariable.day)
        {
            Main.instance.air += Time.fixedDeltaTime;
        }
        else
        {
            Main.instance.water += Time.fixedDeltaTime;
        }
    }

    public bool CanLinkToLeaf()
    {
        return connectedLeaf.Count < maxLeafConnection;
    }

    public int GetDistanceToCore()
    {
        if (leafParent.isCoreLeaf)
        {
            return 1;
        }
        return 1 + leafParent.GetDistanceToCore();
    }
}
