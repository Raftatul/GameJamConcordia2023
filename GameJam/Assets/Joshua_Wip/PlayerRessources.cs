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
        Nutriment = 50;
        Air = 50;
        Water = 50;
        Light = 50;
    }
}
