using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicZoom : MonoBehaviour
{
    public KeyCode key;

    public Camera cam;
    public float maxZoom = 5;
    public float minZoom = 20;
    public float sensitivity = 1;
    public float speed = 30;
    float targetZoom;
    bool zoom;

    public float marginLeft;
    public float marginTop;

    public float zoomStep;

    void Start()
    {
        targetZoom = cam.orthographicSize;
    }

    public void ZoomOut()
    {
        targetZoom += zoomStep;
        //zoom = true;
        StartCoroutine(SmoothCamera());
    }

    public void UpdateSize()
    {
        foreach (var node in TreeCore.instance.leafs)
        {
            if (!InBounds(node.transform.position))
            {
                ZoomOut();
            }
        }
        
        foreach (var node in TreeCore.instance.roots)
        {
            if (!InBounds(node.transform.position))
            {
                ZoomOut();
            }
        }
    }

    private bool InBounds(Vector3 position)
    {
        if (position.x < -GlobalVariable.camBounds.x + marginLeft)
        {
            return false;
        }
        if (position.x > GlobalVariable.camBounds.x - marginLeft)
        {
            return false;
        }
        if (position.y < -GlobalVariable.camBounds.y + marginLeft)
        {
            return false;
        }
        if (position.y > GlobalVariable.camBounds.y - marginLeft)
        {
            return false;
        }

        return true;
    }

    IEnumerator SmoothCamera()
    {
        cam.orthographicSize = cam.orthographicSize + 0.01f;
        yield return new WaitForSeconds(0.01f);
       
        if(cam.orthographicSize <= targetZoom)
        {
        StartCoroutine(SmoothCamera());
        }
        else 
        {
            yield return null ;
        }
    }

}
