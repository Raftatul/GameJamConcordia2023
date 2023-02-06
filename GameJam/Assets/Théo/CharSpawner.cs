using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawner : MonoBehaviour
{
    Camera cam;
    public GameObject prefab;    
    public float spawnInterval = 5f;
    private float spawnTimer = 0f;
    private Vector3 posChar = new(0f,0.2f,0f);

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 screenPoint = transform.position;

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(prefab, screenPoint, Quaternion.identity);
        }
    }
}
