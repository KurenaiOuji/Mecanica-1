using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class RopeMovement : MonoBehaviour
{
    public float swing;
    public Transform fireBalls;
    private BezierCurve _besierCurve;
    float time;

    void Start()
    {
        _besierCurve = GetComponent<BezierCurve>();
    }

    void FixedUpdate()
    {
        ControlPointsMovement();
        FireBallsMovement();
        swing += Time.fixedDeltaTime / 10;
    }

    void FireBallsMovement()
    {
        for (int i = 0; i < fireBalls.childCount; i++)
        {
            float si = (float) i / (fireBalls.childCount - 1f);
            fireBalls.GetChild(i).position = _besierCurve.Bezier(si);
        }
    }

    void ControlPointsMovement()
    {
        float z1 = _besierCurve.P[1].position.z;
        float z2 = _besierCurve.P[2].position.z;

        _besierCurve.P[1].position = CirclePath(5f, z1);
        _besierCurve.P[2].position = CirclePath(5f, z2);

        time += Time.deltaTime;
    }

    Vector3 CirclePath(float radius, float zCoordinate)
    {
        float xCoordinate = radius * Mathf.Sin(swing * time);
        float yCoordinate = radius * Mathf.Cos(swing * time);
        return new Vector3(xCoordinate, yCoordinate, zCoordinate);
    }
}
