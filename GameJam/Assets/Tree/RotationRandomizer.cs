using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RotationRandomizer : MonoBehaviour
{
    public bool rotateOnAwake = true;
    public float minRotation;
    public float maxRotation;
    
    private void Awake()
    {
        if (rotateOnAwake)
        {
            float randomRotation = Random.Range(minRotation, maxRotation);
            transform.rotation =  Quaternion.Euler(transform.rotation.x, transform.rotation.y, randomRotation);
        }
    }
}
