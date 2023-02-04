using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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

        newLeaf.GetComponent<SpriteRenderer>().enabled = false;

        newLeaf.transform.DOScale(Vector3.one, 2).OnComplete(() =>
        {
            newLeaf.transform.localScale = Vector3.zero;
            newLeaf.GetComponent<SpriteRenderer>().enabled = true;
            newLeaf.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        });

        List<Vector3> points = new List<Vector3>();
        points.Add(Vector3.zero);
        points.Add(new Vector3(worldPos.x,0));
        points.Add(worldPos);
        
        newBranch.GetComponent<Branch>().Grow(points.ToArray());
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
