using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Object to Spawn")]
    [SerializeField] private GameObject objectToSpawn;

    [Header("Spawn Param")]
    [SerializeField] private bool ranDelay;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float offset = 2f;
    private float timeToWait;

    [Header("Screen Bounds")]
    [SerializeField] private Vector2 cordonates = GlobalVariable.camBounds;

    void Awake()
    {
        StartCoroutine(SpawnSeperat());
    }

    IEnumerator SpawnSeperat()
    {
        if (ranDelay)
        {
            timeToWait = Random.Range(minSpawnDelay, spawnDelay);
        }
        else
        {
            timeToWait = spawnDelay;
        }
        WaitForSeconds waitRepeat = new(timeToWait);
        int ran = Random.Range(0 + (int)offset, (int)GlobalVariable.camBounds.y - (int)offset);

        if (true)
        {
             GameObject truc = Instantiate(objectToSpawn, new Vector2(GlobalVariable.camBounds.x + offset,ran), Quaternion.identity);
             truc.transform.SetParent(transform);
             Vector3 position = new();
             position = truc.transform.position;
             position.z = 0;
             truc.transform.localPosition = position;
        }
        yield return waitRepeat;
        StartCoroutine(SpawnSeperat());
    }
}
