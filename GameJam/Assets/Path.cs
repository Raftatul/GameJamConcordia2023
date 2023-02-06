using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Vector3[] GetPoints()
    {
        List<Vector3> childs = new List<Vector3>();
        foreach(Transform child in transform)
        {
            childs.Add(child.position);
        }
        return childs.ToArray();
    }
}
