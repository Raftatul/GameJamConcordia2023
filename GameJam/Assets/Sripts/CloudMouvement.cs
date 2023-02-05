using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class CloudMouvement : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    
    [SerializeField] private float mouvSpeed = 40;
    [SerializeField] private Image selfCloud;
    private bool fade = false;

    private void Awake()
    {
        mouvSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void FixedUpdate()
    {
        if (!fade)
        {
            this.transform.position += new Vector3(-1 * mouvSpeed * Time.deltaTime,0,0);
        }

        if (!GlobalVariable.clouds && !fade)
        {
            fade = true;
            selfCloud.DOFade(0, 0.5f).OnComplete(() => {
                Destroy(gameObject); 
            });
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fade = true;

        GlobalVariable.air += 1;

        selfCloud.DOFade(0, 0.5f).OnComplete(() => {
            Destroy(gameObject);
        });
    }
}
