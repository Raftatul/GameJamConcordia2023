using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAmount : MonoBehaviour
{
    [SerializeField] private Ressources ressources;

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new(1, 1 * ressources.RessourcesCurr / ressources.RessourcesAmount, 0);
    }
}
