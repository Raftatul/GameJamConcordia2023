using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ressources : MonoBehaviour
{
    public float Weight;
    public float RessourcesAmount;


    public void GiveRandomSize()
    {
        float x = Random.Range(0.1f, 1.5f);
        float y = Random.Range(0.1f, 1.5f);
        transform.localScale = new Vector2(x, y);
        transform.DOScale(new Vector2(x, y), 0.01f);

        //Debug.Log(new Vector2(x, y));
        //Debug.Log(gameObject.GetComponent<Transform>().localScale);
        //Debug.Log("______________________");

        RessourcesAmount = Random.Range(1, 10);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Root")
        {
            Debug.Log("ccccc");
        }
    }
}
