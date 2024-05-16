using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePath : MonoBehaviour
{
    public float amplitudeX, amplitudeY, frequency;
    [Range(-90, 90f)]
    public float phase;
    public bool isActive = true;
    private Vector3 center;
    private float time;

    void Start()
    {
        center = transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            time += Time.fixedDeltaTime;
        }
        transform.position = Path();
    }

    Vector3 Path()
    {
        float d = Denominator();
        float x = amplitudeX * Mathf.Cos(frequency * time + phase)/d;
        float y = amplitudeY * Mathf.Sin(frequency * time + phase)/d;

        return new Vector3(x+center.x, y+center.y, center.z);
    }

    float Denominator()
    {
        float pi = Mathf.PI;
        float cos = Mathf.Cos(frequency * time + phase + 0.25f*pi);
        float sin = Mathf.Sin(frequency * time + phase + 0.25f * pi);
        return Mathf.Sqrt(2) * (Mathf.Abs(cos)+ Mathf.Abs(sin));
    }

}
