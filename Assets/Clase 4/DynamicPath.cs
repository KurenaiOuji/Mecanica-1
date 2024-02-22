using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DynamicPath : MonoBehaviour
{
    [Range(0.01f, 5)] public float r;
    [Range(-5f, 5f)] public float w;
    [Range(0f, 10)] public float h;
    [Range(0f, 10f)] public float t;

    public Transform platform;

    List<Vector3> points = new List<Vector3>();
    
    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
    }

    void Update()
    {
        SamplePoints();
        platform.position = F(t);
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t = 0; t < 10f; t += 0.025f)
        {
            Vector3 newPoint = F(t);
            points.Add(newPoint);
        }

        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    Vector3 F(float t)
    {
        float x = Mathf.Exp(r * t) * Mathf.Cos(w * t);
        float y = h * t;
        float z = Mathf.Exp(r * t) * Mathf.Sin(w * t);

        return new Vector3(x, y, z);
    }
}
