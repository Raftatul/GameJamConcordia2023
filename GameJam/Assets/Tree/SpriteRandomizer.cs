using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpriteRandomizer : MonoBehaviour
{
    public Sprite[] sprites;

    private void Awake()
    {
        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        }

        if (GetComponent<Image>())
        {
            GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
