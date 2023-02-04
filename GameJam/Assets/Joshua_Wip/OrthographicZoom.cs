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

    void Start()
    {
        targetZoom = cam.orthographicSize;
    }

    public void ZoomOut()
    {
        targetZoom += 2;
        //zoom = true;
        StartCoroutine(SmoothCamera());
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
