using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PathFollower : MonoBehaviour
{
    public Path path;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOPath(path.GetPoints(), 5).SetEase(Ease.Linear);
        }
    }
}
