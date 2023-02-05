using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RessourcesHarvester : MonoBehaviour
{
    [SerializeField] float AirGain = 1;

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
            Vector3 to = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(0.3f, 0.5f));
            //item.transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 1).SetEase(Ease.OutElastic).SetLoops(3, LoopType.Yoyo);
            //item.transform.DOShakePosition(1, 0.5, 5, 45, false, true).SetDelay(0.3); //.SetEase(easetype).SetLoops(numberOfLoop, loopType).From();
            //item.transform.DOMove((item.transform.position + to), 2).SetDelay(0.2f).SetEase(Ease.InOutSine).SetLoops(4, LoopType.Yoyo);

            //item.transform.DOPunchPosition(to, 3, 0, 0.1f).SetDelay(0.3f).SetEase(Ease.InOutSine);
            StartCoroutine(GainWind());
        }
    }

    IEnumerator GainWind()
    {
        Debug.Log("wewee");
        yield return new WaitForSeconds(0.1f);
        Player.Air += AirGain;
        GlobalVariable.air += (int)AirGain;

    }

}
