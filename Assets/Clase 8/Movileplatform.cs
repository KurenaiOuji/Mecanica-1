using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movileplatform : MonoBehaviour
{
    public Transform platformA;
    public Transform platformB;

    [Range(0f, 1f)]
    public float lerpParameter;

    public float time;
    public float frecuency;
    public float phase;

    void Update()
    {
        time += Time.deltaTime;
        lerpParameter = 0.5f * (1 + Mathf.Sin(frecuency * time - phase));
        transform.position = LerpUwu(platformA.position, platformB.position, lerpParameter);
    }

    Vector3 LerpUwu(Vector3 A, Vector3 B, float s)
    {
        return (B - A) * s + A;
    }
}
