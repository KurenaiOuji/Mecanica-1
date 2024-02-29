using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShock
{
    public static Vector3 Position(float time, Vector3 initialPosition, Vector3 initialVelocity)
    {
        Vector3 gravity = new Vector3(0,-9.81f,0);

        return 0.5f * gravity * time * time + initialVelocity * time + initialPosition;
    }

    public static Vector3 Velocity(float time, Vector3 initialPosition, Vector3 initialVelocity)
    {
        Vector3 gravity = new Vector3(0, -9.81f, 0);

        return gravity * time + initialVelocity;
    }

    public static float FlyingTime(Vector3 initialPosition, Vector3 initialVelocity)
    {
        float g = 9.81f;
        float y0 = initialPosition.y;
        float v0y = initialVelocity.y;
        float result = (v0y + Mathf.Sqrt(v0y * v0y + 2 * g * y0)) / g;
        
        return result;
    }
}
