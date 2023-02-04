using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMouvement : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("leaf"))
        {
            GlobalVariable.light += 1;
        }
        Destroy(gameObject);
    }
}
