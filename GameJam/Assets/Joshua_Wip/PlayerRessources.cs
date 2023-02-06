using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PlayerRessources")]
public class PlayerRessources : ScriptableObject
{
    public List<Ressources> Tap = new();

    public float Nutriment;
    public float Air;
    public float Water;
    public float Light;

    public void debuglist()
    {
        foreach (var item in Tap)
        {
            Debug.Log(item.name);
        }
    }

    public void Clear()
    {
        Tap.Clear();
        Nutriment = 12;
        Air = 12;
        Water = 12;
        Light = 12;

        GlobalVariable.nutriment = (int)Nutriment;
        GlobalVariable.water = (int)Air;
        GlobalVariable.air = (int)Water;
        GlobalVariable.light = (int)Light;
    }
}
