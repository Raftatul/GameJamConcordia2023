using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSuns : MonoBehaviour
{

    [Header("Object to Spawn")]
    [SerializeField] private GameObject objectToSpawn;

    [Header("Spawn Param")]
    [SerializeField] private bool ranDelay;
    [SerializeField] private float spawnDelay = 2f;
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
            timeToWait = Random.Range(0.5f,spawnDelay);
        }
        else
        {
            timeToWait = spawnDelay - (Camera.main.orthographicSize * 0.01f);
        }
        WaitForSeconds waitRepeat = new(timeToWait);
        if (GlobalVariable.day)
        {
            int ran = Random.Range(-(int)GlobalVariable.camBounds.x + (int)offset, (int)GlobalVariable.camBounds.x - (int)offset);

            if (GlobalVariable.clouds)
            {
                int ran2 = Random.Range(0, 100);
                if (ran2 <= 50)
                {
                    Instantiate(objectToSpawn, new Vector2(ran,GlobalVariable.camBounds.y+2), Quaternion.identity).transform.SetParent(transform);
                }
            }
            else if (!GlobalVariable.rain)
            {
                Instantiate(objectToSpawn, new Vector2(ran, GlobalVariable.camBounds.y + 2), Quaternion.identity).transform.SetParent(transform);
            }
        }
        yield return waitRepeat;
        StartCoroutine(SpawnSeperat());
    }
}
