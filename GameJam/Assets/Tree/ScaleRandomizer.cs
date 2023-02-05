using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScaleRandomizer : MonoBehaviour
{
    public float minScale;
    public float maxScale;
    
    private void Awake()
    {
        float randScale = Random.Range(minScale, maxScale);
        Vector2 scale = new Vector2(randScale, randScale);
        transform.localScale = scale;
    }
}
