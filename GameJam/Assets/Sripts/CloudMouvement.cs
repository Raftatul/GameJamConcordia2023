using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CloudMouvement : MonoBehaviour
{
    [SerializeField] private float mouvSpeed = 40;
    [SerializeField] private Image selfCloud;
    private bool fade = false;

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(-1 * mouvSpeed * Time.deltaTime,0,0);

        if (!GlobalVariable.clouds && !fade)
        {
            fade = true;
            selfCloud.DOFade(0, 3f).OnComplete(() => {
                Destroy(gameObject); 
            });
        }
    }
}
