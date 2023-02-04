using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSuns : MonoBehaviour
{

    [Header("Object to Spawn")]
    [SerializeField] private List<GameObject> objectToSpawn;

    [Header("Where to Spawn ?")]
    [SerializeField] private List<Transform> placeToSpawn;

    [Header("Spawn Rate")]
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private bool ranDelay;
    [SerializeField] private float timeToWait;

    void Awake()
    {
        StartCoroutine(SpawnSeperat());
    }

    IEnumerator SpawnSeperat()
    {
        if (ranDelay)
        {
            timeToWait = Random.Range(0.5f,spawnDelay);
        }
        else
        {
            timeToWait = spawnDelay;
        }
        WaitForSeconds waitRepeat = new(timeToWait);
        if (GlobalVariable.day)
        {
            int ran2 = Random.Range(0, objectToSpawn.Count);
            int ran = Random.Range(0, placeToSpawn.Count);

            if (GlobalVariable.clouds)
            {
                int ran3 = Random.Range(0, 100);
                if (ran3 <= 50)
                {
                    Instantiate(objectToSpawn[ran2], placeToSpawn[ran].position, placeToSpawn[ran].rotation).transform.SetParent(transform);
                }
            }
            else if (!GlobalVariable.rain)
            {
                Instantiate(objectToSpawn[ran2], placeToSpawn[ran].position, placeToSpawn[ran].rotation).transform.SetParent(transform);
            }
        }
        yield return waitRepeat;
        StartCoroutine(SpawnSeperat());
    }
}
