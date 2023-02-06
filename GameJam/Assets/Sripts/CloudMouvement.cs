using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CloudMouvement : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    
    [SerializeField] private float mouvSpeed = 40;
    [SerializeField] private SpriteRenderer selfCloud;
    private bool fade = false;

    private void Awake()
    {
        mouvSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        if (!fade)
        {
            transform.position += new Vector3(-1 * mouvSpeed * Time.deltaTime,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Leaf"))
        {
            return;
        }
        fade = true;

        GlobalVariable.air += 1;

        selfCloud.DOFade(0, 0.5f).OnComplete(() => {
            Destroy(gameObject);
        });
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
