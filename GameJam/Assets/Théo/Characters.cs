using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Characters : MonoBehaviour
{
    #region Variables

    private Camera cam;
    public float speed = 1.0f;
    public Vector3 direction = Vector3.zero;
    public Vector3 endValue;
    public Rigidbody2D charRigid;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public GameObject prefab;

    private bool isDottedWeen = false;
    public float duration = 5f;
    public float duration2 = 6f;
    public float strenght = 1;
    public int vibrato = 10;
    public float randomness = 90;
    public bool snapping = false;
    public bool fadeOut = true;

   #endregion Variables

    void Start()
    {
        cam = Camera.main;
        direction = Random.onUnitSphere;
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        direction = (direction + Random.onUnitSphere * 0.1f).normalized;

        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

        if (screenPoint.x > 1)
        {
            screenPoint.x = 0;
            transform.position = cam.ViewportToWorldPoint(screenPoint);
        }

        else if (screenPoint.x < 0)
        {
            screenPoint.x = 1;
            transform.position = cam.ViewportToWorldPoint(screenPoint);
        }

        if (screenPoint.y >= 1.1)
        {
            direction = -direction;
        }

        else if ((screenPoint.y <= 0.52f)&&(isDottedWeen == false))
        {
            isDottedWeen = true;

            endValue = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

            this.transform.DOShakePosition(duration, strenght, vibrato, randomness, snapping, fadeOut, ShakeRandomnessMode.Full);
            this.transform.DOLocalMove(endValue, duration2, snapping);
            this.spriteRenderer.DOFade(0, 3f).OnComplete(() => {
                Destroy(gameObject);
            });
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}




