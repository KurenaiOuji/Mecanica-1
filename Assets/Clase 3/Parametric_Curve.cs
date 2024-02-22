using System.Collections.Generic;
using UnityEngine;

public class Parametric_Curve : MonoBehaviour
{
    public float tMin, tMax;
    List<Vector3> points = new List<Vector3>();

    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.5f;
        SamplePoints();
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t = tMin; t < tMax; t += 0.025f)
        {
            Vector3 newPoint = F1(t);
            points.Add(newPoint);
        }

        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    Vector3 F1(float t)
    {
        float r = 7 * (t - Mathf.Sin(t));
        float w = 0;
        float h = 7 * (1 - Mathf.Cos(t));

        float x = r * Mathf.Cos(w * t); 
        float y = h * t;
        float z = h * Mathf.Sin(w * t);
        return new Vector3(x, y, z);
    }
}
