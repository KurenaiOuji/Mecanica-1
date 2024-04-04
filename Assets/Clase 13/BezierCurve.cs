using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BezierCurve : MonoBehaviour
{
    private int curvePoints = 100;
    private List<Transform> P = new List<Transform>();
    private int n;

    void Awake()
    {
        InitCurve();
    }

    void Update()
    {
        SampleCurve();
    }

    public void InitCurve()
    {
        int i = 0;
        float deltaZ = 5f;
        foreach (Transform child in transform)
        {
            P.Add(child);
            child.localPosition = i * deltaZ * Vector3.forward;
            i++;
        }

        n = P.Count - 1;
        GetComponent<LineRenderer>().positionCount = curvePoints;
        GetComponent<LineRenderer>().widthMultiplier = 0.25f;

        
    }

    public void SampleCurve()
    {
        for (int i = 0; i < curvePoints; i++)
        {
            float s = (float)i / (float)(curvePoints - 1);
            GetComponent<LineRenderer>().SetPosition(i, Bezier(s));
        }
    }

    // Bezier Functions

    private int Factorial(int n)
    {
        int result = 1;
        for (int k = 1; k <= n; k++)
        {
            result *= k;
        }
        return result;
    }

    private int Binomial(int n, int i)
    {
        int result = Factorial(n) / (Factorial(i) * Factorial(n - i));
        return result;
    }

    private float PolBern(int n, int i, float s)
    {
        float result = Binomial(n, i) * Mathf.Pow(1f - s, n - i) * Mathf.Pow(s, i);
        return result;
    }

    public Vector3 Bezier(float s)
    {
        Vector3 result = Vector3.zero;
        for (int i = 0; i <= n; i++)
        {
            result += PolBern(n, i, s) * P[i].position;
        }
        return result;
    }

    public Vector3 BezierDerivative(float s)
    {
        Vector3 result = Vector3.zero;
        for (int i = 0; i <= n - 1; i++)
        {
            result += PolBern(n - 1, i, s) * (P[i + 1].position - P[i].position);
        }
        return n * result;
    }
}
