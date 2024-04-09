using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVehicle : MonoBehaviour
{
    public float speed, rotSpeed;
    public Transform sphere;

    float sphereRadius;

    void Start()
    {
        sphereRadius = sphere.localScale.x / 2f;
        transform.position = new Vector3(0, sphereRadius, 0f);
    }

    void Update()
    {
        surfaceMovement();    
    }

    void surfaceMovement()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(transform.up, rotSpeed * hInput * dt, Space.World);

        Vector3 translatePosition = transform.position + transform.forward * dt * speed;
        Vector3 translatedUp = NormalToSurface(translatePosition);
        float dotProduct = Vector3.Dot(transform.forward, translatedUp);
        Vector3 translatedForward = (transform.forward - dotProduct * translatedUp).normalized;

        Quaternion newRotation = Quaternion.LookRotation(translatedForward, translatedUp);
        transform.rotation = newRotation;

        sphereRadius = sphere.localScale.x / 2f;
        Vector3 newPosition = sphere.position + (sphereRadius + 5f) * NormalToSurface(translatePosition);

        transform.position = newPosition;
    }

    Vector3 NormalToSurface(Vector3 position)
    {
        Vector3 relativePosition = position - sphere.position;
        Vector3 normal = relativePosition.normalized;
        return normal;
    }
}
