using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("Object to Spawn")]
    [SerializeField] private List<GameObject> objectToSpawn;                      // The object to spawn

    [Header("Where to Spawn ?")]
    [SerializeField] private List<Transform> placeToSpawn;                  // l=List of places to spawn your object

    [Header("Spawn Rate")]
    [SerializeField] private float spawnDelay = 2f;                              // Every ... Secondes
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
        if (GlobalVariable.clouds)
        {
            int ran2 = Random.Range(0,objectToSpawn.Count);
            int ran = Random.Range(0, placeToSpawn.Count);
            Instantiate(objectToSpawn[ran2], placeToSpawn[ran].position, placeToSpawn[ran].rotation).transform.SetParent(transform);
        }
        yield return waitRepeat;
        StartCoroutine(SpawnSeperat());
    }
}
