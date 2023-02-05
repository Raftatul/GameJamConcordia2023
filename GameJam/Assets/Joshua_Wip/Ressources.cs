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

    public enum ResourceType
    {
        AIR,
        LIGHT,
        NUTRIMENT,
        WATER,
        NONE,
    }
    public ResourceType Type;

    public void GiveRandomSize()
    {
        float x = Random.Range(0.1f, 1.5f);
        float y = Random.Range(0.1f, 1.5f);
        transform.localScale = new Vector2(x, y);
        transform.DOScale(new Vector2(x, y), 0.01f);

        //Debug.Log(new Vector2(x, y));
        //Debug.Log(gameObject.GetComponent<Transform>().localScale);
        //Debug.Log("______________________");

        RessourcesAmount = (x * y) * 20;
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


    public void GetRessources()
    {
        float gain = 0;
        if (RessourcesCurr > 0)
        {
            RessourcesCurr = RessourcesCurr - RessourcesPerTick;
            gain = RessourcesPerTick/2;
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
