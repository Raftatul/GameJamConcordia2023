using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMouvement : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-1 * Time.deltaTime,0,0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
