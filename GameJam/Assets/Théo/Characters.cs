using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Characters : MonoBehaviour
{
    public Camera cam;
    public float speed = 1.0f;
    public Vector3 direction = Vector3.zero;
    public float bottomLimit = 0.5f;
    public float topLimit = 0.60f;
    public float attractionStrength = 1f;
    public Rigidbody2D charRigid;
    public float mult = 0.1f;

    void Start()
    {
        direction = Random.onUnitSphere;
    }

    void Update()
    {
            transform.position += direction * speed * Time.deltaTime;
            direction = (direction + Random.onUnitSphere * 0.1f).normalized;

            Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

            // Redirection vers l'intérieur lorsque la mouche se rapproche du sol
            if (screenPoint.y < bottomLimit)
            {
                direction = Vector3.Lerp(direction, -direction, (bottomLimit - screenPoint.y) / bottomLimit);
            }

            // Redirection vers l'intérieur lorsque la mouche se rapproche du plafond
            if (screenPoint.y > topLimit)
            {
                direction = Vector3.Lerp(direction, -direction, (screenPoint.y - topLimit) / topLimit);
            }

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
            if (screenPoint.y > 1)
            {
                screenPoint.y = 0;
                transform.position = cam.ViewportToWorldPoint(screenPoint);
            }
            else if (screenPoint.y < 0)
            {
                screenPoint.y = 1;
                transform.position = cam.ViewportToWorldPoint(screenPoint);
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
        

        //transform.position += direction * speed * Time.deltaTime;
        //direction = (direction + Random.onUnitSphere * 0.1f).normalized;

        //Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        //if (screenPoint.x > 1 || screenPoint.x < 0 || screenPoint.y > 1 || screenPoint.y < 0)
        //{
        //    direction = -direction;
        //}


        //        transform.position += direction * speed * Time.deltaTime;
        //        direction = (direction + Random.onUnitSphere * 0.1f).normalized;

        //        Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        //        if (screenPoint.x > 1)
        //        {
        //            screenPoint.x = 0;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        else if (screenPoint.x < 0)
        //        {
        //            screenPoint.x = 1;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        if (screenPoint.y > 1)
        //        {
        //            screenPoint.y = 0;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        else if (screenPoint.y < 0)
        //        {
        //            screenPoint.y = 1;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }

        //    transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //    Vector3 center = new Vector3(0.5f, 0.5f, 0f);
        //    Vector3 directionToCenter = center - screenPoint;
        //    direction += directionToCenter * redirectionForce * Time.deltaTime;
        //}

        //transform.position += direction * speed * Time.deltaTime;
        //direction = (direction + Random.onUnitSphere * 0.1f).normalized;

        //Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        //if (screenPoint.x > 1 || screenPoint.x < 0 || screenPoint.y > 1 || screenPoint.y < 0)
        //{
        //    direction = -direction;
        //}


        //        transform.position += direction * speed * Time.deltaTime;
        //        direction = (direction + Random.onUnitSphere * 0.1f).normalized;

        //        Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        //        if (screenPoint.x > 1)
        //        {
        //            screenPoint.x = 0;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        else if (screenPoint.x < 0)
        //        {
        //            screenPoint.x = 1;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        if (screenPoint.y > 1)
        //        {
        //            screenPoint.y = 0;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }
        //        else if (screenPoint.y < 0)
        //        {
        //            screenPoint.y = 1;
        //            transform.position = camera.ViewportToWorldPoint(screenPoint);
        //        }

        //    transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //    Vector3 center = new Vector3(0.5f, 0.5f, 0f);
        //    Vector3 directionToCenter = center - screenPoint;
        //    direction += directionToCenter * redirectionForce * Time.deltaTime;
        //}
