using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Branch : MonoBehaviour
{
    public List<GameObject> points;

    public void Grow(Vector3[] new_point)
    {
        print(new_point.Length);
        GetComponent<LineRenderer>().positionCount = new_point.Length;
        
        for (int i = 0; i < new_point.Length; i++)
        {
            GameObject newPoint = Instantiate(new GameObject("Point"));
            points.Add(newPoint);
        }

        points[0].transform.DOMove(new_point[0], 1);
        points[1].transform.DOMove(new_point[0], 1);
        points[2].transform.DOMove(new_point[0], 1).OnComplete(() =>
        {
            points[1].transform.DOMove(new_point[1], 1).OnComplete(() =>
            {
                points[2].transform.DOMove(new_point[2], 1);
            });
        });
    }

    private void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            GetComponent<LineRenderer>().SetPosition(i, points[i].transform.position);
        }
    }
}
