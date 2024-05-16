using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 direction;
    public float frequency;
    public bool isActive = false;
    
    void FixedUpdate()
    {
        if (isActive)
        {
            transform.Rotate(direction, frequency * Time.fixedDeltaTime);
        }

    }


}
