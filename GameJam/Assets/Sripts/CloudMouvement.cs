using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMouvement : MonoBehaviour
{
    [SerializeField] private float mouvSpeed = 40;

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-1 * mouvSpeed * Time.deltaTime,0,0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
