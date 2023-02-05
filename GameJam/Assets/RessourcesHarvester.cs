using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    public void Listener_Wind()
    {
        Debug.Log("wind");
        TreeCore tree = TreeCore.instance;

        foreach (var item in tree.leafs)
        {
            item.transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 1).SetEase(Ease.OutElastic).SetLoops(3, LoopType.Yoyo);
        }
    }

}
