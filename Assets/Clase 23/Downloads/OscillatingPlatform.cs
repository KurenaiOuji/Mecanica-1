using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingPlatform : MonoBehaviour
{
    public Vector3 direction;
    public float amplitude, frequency;
    [Range(-90, 90f)]
    public float phase;
    public bool isActive = true;
    private Vector3 center;
    private float time;

    void Start()
    {
        center = transform.position;
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            time += Time.fixedDeltaTime;
        }
        transform.position = MoveFunction();
    }

    Vector3 MoveFunction()
    {
        float sinFunction = Mathf.Sin(frequency * time + phase*Mathf.Deg2Rad);
        return center + amplitude * sinFunction * (direction.normalized);
    }

}
