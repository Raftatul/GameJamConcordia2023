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
    [SerializeField] private Vector2 coordonate;

    void Awake()
    {
        StartCoroutine(SpawnSeperat());
    }

    IEnumerator SpawnSeperat()
    {
        coordonate = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
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
            int ran = Random.Range(-(int)coordonate.x + (int)offset, (int)coordonate.x - (int)offset);

            if (GlobalVariable.clouds)
            {
                int ran2 = Random.Range(0, 100);
                if (ran2 <= 50)
                {
                    Instantiate(objectToSpawn, new Vector2(ran,coordonate.y+2), Quaternion.identity).transform.SetParent(transform);
                }
            }
            else if (!GlobalVariable.rain)
            {
                Instantiate(objectToSpawn, new Vector2(ran, coordonate.y + 2), Quaternion.identity).transform.SetParent(transform);
            }
        }
        yield return waitRepeat;
        StartCoroutine(SpawnSeperat());
    }
}
