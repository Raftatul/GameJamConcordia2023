using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Branch : MonoBehaviour
{
    public AudioSource growSource;
    public List<GameObject> points;

    public bool followPoints = true;

    public void Grow(Vector3[] new_point)
    {
        growSource.Play();
        GetComponent<LineRenderer>().positionCount = new_point.Length;
        
        for (int i = 0; i < new_point.Length; i++)
        {
            GameObject newPoint = Instantiate(new GameObject("Point"));
            points.Add(newPoint);
            
        }
        
        points[1].transform.DOMove(new_point[1], 1);
        points[2].transform.DOMove(new_point[1], 1).OnComplete(() =>
        {
            points[2].transform.DOMove(new_point[2], 1).OnComplete(() =>
            {
                followPoints = false;
                foreach (var point in points)
                {
                    Destroy(point);
                }
                points.Clear();
            });
        });
    }

    private void Update()
    {
        if (!followPoints)
        {
            return;
        }
        for (int i = 0; i < points.Count; i++)
        {
            GetComponent<LineRenderer>().SetPosition(i, points[i].transform.position);
        }
    }
}
