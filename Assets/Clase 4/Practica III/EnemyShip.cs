using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float r;
    public float w0, w1;
    public float f0, f1;
    public float h;
    float t;

    void Update()
    {
        float dt = Time.deltaTime;
        t += dt;
        transform.position = Path();
        transform.forward = Tangent();
    }

    Vector3 Path()
    {
        float x = r * Mathf.Cos(w0 * t + f0);
        float y = h * Mathf.Sin(w1 * t + f1);
        float z = r * Mathf.Cos(w0 * t + f0);
        return new Vector3(x, y, z);
    }

    Vector3 Tangent()
    {
        float x = -w0 * r * Mathf.Sin(w0 * t + f0);
        float y = w1 * h * Mathf.Cos(w1 * t * f1);
        float z = w0 * r * Mathf.Cos(w0 * t *f0);
        return new Vector3(x, y, z);
    }
}
