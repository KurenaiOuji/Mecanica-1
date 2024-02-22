using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ParametricCurvesResume : MonoBehaviour
{
    public float tMin;
    public float tMax;

    public enum FunctionKind
    {
        kind0,
        kind1,
        kind2,
        kind3
    }

    public FunctionKind functionKind;

    List<Vector3> points = new List<Vector3>();  


    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
    }

    
    void Update()
    {
        SamplePoints();
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t = tMin; t < tMax; t += 0.025f)
        {
            Vector3 newPoint = F(t);
            points.Add(newPoint);
        }
        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    // Función que engloba y selecciona los diferentes tipos de funciones F1, F2, F3
    // Se selecciona la que se encuentre habilitada con el enumerador

    Vector3 F(float t)
    {
        Vector3 vectorFunction = Vector3.zero;
        switch (functionKind)
        {
            case FunctionKind.kind1:
                vectorFunction =  F1(t);
                break;

            case FunctionKind.kind2:
                vectorFunction = F2(t);
                break;

            case FunctionKind.kind3:
                vectorFunction = F3(t);
                break;

            default:
                vectorFunction = F0(t);
                break;

        }
        return vectorFunction;  
    }

    Vector3 F0(float t)
    {
        return Vector3.zero;
    }

    // Funciones Vectoriales para graficar
    // A partir de aquí realizan las modificaciones!!

    Vector3 F1(float t)
    {
        float r = 5f;
        float w = 2.5f;
        float h = 1.5f;
        float x = r * Mathf.Cos(w * t);
        float y = h * t;
        float z = r * Mathf.Sin(w * t);
        return new Vector3(x, y, z);
    }

    Vector3 F2(float t)
    {
        float x = 0;
        float y = 7 * (1 - Mathf.Cos(t));
        float z = 7 * (t-Mathf.Sin(t));
        return new Vector3(x, y, z);
    }

    Vector3 F3(float t)
    {
        float cosT = Mathf.Cos(t);  
        float sinT = Mathf.Sin(t);
        float cos4T = Mathf.Cos(4*t);
        float sinT12 = Mathf.Sin(t/12);
        float sin5T12 = Mathf.Pow(sinT12, 5);
        float expCosT = Mathf.Exp(Mathf.Cos(t));

        float x = sinT * (expCosT - 2*cos4T - sin5T12 );
        float y = cosT * (expCosT - 2 * cos4T - sin5T12);
        
        return new Vector3(x, y, 0);
    }
}
