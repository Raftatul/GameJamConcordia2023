using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesHarvester : MonoBehaviour
{
    public PlayerRessources Player;
    public float IncomeTime;


    void Start()
    {
        Player.Clear();
        StartCoroutine(GetRessources());
    }


    IEnumerator GetRessources()
    {
        yield return new WaitForSeconds(IncomeTime);
        foreach (var item in Player.Tap)
        {
            item.GetRessources();
        }
        StartCoroutine(GetRessources());
    }
}
