using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ressources : MonoBehaviour
{
    public PlayerRessources Player;
    public float Weight;
    public float RessourcesAmount;
    public float RessourcesCurr;
    public float RessourcesPerTick;

    public GameObject Nutriment;
    bool rooted;


    public enum ResourceType
    {
        AIR,
        LIGHT,
        NUTRIMENT,
        WATER,
        NONE,
    }
    public ResourceType Type;


    private void Start()
    {
        if (Type == ResourceType.NONE)
        {
            StartCoroutine(TransformToNutriment());
        }
    }

    IEnumerator TransformToNutriment()
    {
        yield return new WaitForSeconds(Random.Range(10, 30));
        if (!rooted && Nutriment.activeInHierarchy)
        {
            float random = Random.Range(0, 101);
            if (random >= 95)
            {
                Nutriment.GetComponent<Ressources>().GiveRandomSize();
                Nutriment.SetActive(true);
            }
        }
        StartCoroutine(TransformToNutriment());
    }

    public void GiveRandomSize()
    {
        float x = Random.Range(0.5f, 1.5f);
        //float y = Random.Range(0.91f, 1.11f);
        transform.localScale = new Vector2(x, x);
        transform.DOScale(new Vector2(x, x), 0.01f);

        //Debug.Log(new Vector2(x, y));
        //Debug.Log(gameObject.GetComponent<Transform>().localScale);
        //Debug.Log("______________________");

        RessourcesAmount = (x * x) * 20;
        RessourcesCurr = RessourcesAmount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Root"))
        {
            //print(collision.gameObject.GetComponent<Ressources>());
            Player.Tap.Add(this);
            Player.debuglist();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Root"))
        {
            rooted = true;
        }
    }


    public void GetRessources()
    {
        float gain = 0;
        if (RessourcesCurr > 0)
        {
            RessourcesCurr = RessourcesCurr - RessourcesPerTick;
            gain = RessourcesPerTick / 2;
        }

        switch (Type)
        {
            case (ResourceType.AIR):
                Player.Air += gain;
                break;

            case (ResourceType.LIGHT):
                Player.Light += gain;

                break;

            case (ResourceType.NUTRIMENT):
                Player.Nutriment += gain;

                break;

            case (ResourceType.WATER):
                Player.Water += gain;

                break;

            case (ResourceType.NONE):

                break;
        }


    }


}
