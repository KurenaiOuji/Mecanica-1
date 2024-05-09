using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBase : MonoBehaviour
{
    public float maxSpeed, slerp;
    private float speed;
    public Transform[] engines;

    void Update()
    {
        PlatformRotation();
        RotationEngines();
    }

    void PlatformRotation()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("HorizontalRoll");
        speed = maxSpeed * hInput;
        Vector3 eulers = new Vector3 (0f, speed * dt, 0f);
        transform.Rotate(eulers, Space.Self);
    }

    void RotationEngines()
    {
        float dt = Time.deltaTime;
        float targetAngle = -90f * speed / maxSpeed;
        Quaternion targetRotation = Quaternion.Euler (targetAngle, 0f, 0f);
        foreach(Transform engine in engines)
        {
            engine.localRotation = Quaternion.Slerp(engine.localRotation, targetRotation, slerp * dt);
        }
    }
}
