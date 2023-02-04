using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Root : MonoBehaviour
{
    public static int maxLeafConnection = 3;
    
    public LineRenderer branchRef;
    public List<GameObject> connectedRoot;


    private void Start()
    {
        TreeCore.instance.roots.Add(gameObject);
    }

    public void ConnectRoot(GameObject newRoot)
    {
        connectedRoot.Add(newRoot);
        LineRenderer newBranch = Instantiate(branchRef, transform.position, Quaternion.identity);
        Vector3 worldPos = transform.InverseTransformPoint(newRoot.transform.position);
        newBranch.transform.SetParent(transform);
        
        newRoot.GetComponent<SpriteRenderer>().enabled = false;

        newRoot.transform.DOScale(Vector3.one, 2).OnComplete(() =>
        {
            newRoot.transform.localScale = Vector3.zero;
            newRoot.GetComponent<SpriteRenderer>().enabled = true;
            newRoot.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        });

        List<Vector3> points = new List<Vector3>();
        points.Add(Vector3.zero);
        points.Add(new Vector3(worldPos.x,0));
        points.Add(worldPos);
        
        newBranch.GetComponent<Branch>().Grow(points.ToArray());
    }

    public bool CanLinkToRoot()
    {
        return connectedRoot.Count < maxLeafConnection;
    }
}
