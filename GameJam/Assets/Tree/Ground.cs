using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool height = true;
    public bool width = true;

    public bool applyOnScale = true;
    public bool applyOnSprite = false;

    private Vector3 startPos;

    private Collider2D _collider;

    private void Start()
    {
        startPos = transform.position;
        _collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector3 scale = new Vector3(3.6f * Camera.main.orthographicSize, Camera.main.orthographicSize, 1);
        if (!height)
        {
            if (applyOnScale)
            {
                scale.y = transform.localScale.y;
            }
            else
            {
                scale.y = GetComponent<SpriteRenderer>().size.y;
            }
        }
        if (!width)
        {
            if (applyOnScale)
            {
                scale.x = transform.localScale.x;
            }
            else
            {
                scale.x = GetComponent<SpriteRenderer>().size.x;
            }
        }

        if (applyOnScale)
        {
            transform.localScale = scale;
        }
        else if(applyOnSprite)
        {
            GetComponent<SpriteRenderer>().size = scale;
            transform.position = startPos * scale.x;
        }
    }
}
