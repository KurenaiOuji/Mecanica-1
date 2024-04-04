using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArrow : MonoBehaviour
{
    public Vector3 P0, V0;
    public bool fired;
    public Transform shootPoint;
    float time;

    void Start()
    {
        fired = false;
        GetComponent<TrailRenderer>().Clear();
        GetComponent<TrailRenderer>().emitting = false;
    }

    void Update()
    {
        if (fired)
        {
            time += Time.deltaTime;
            transform.position = ArrowPosition();
            transform.forward = ArrowVelocity();
        }    
        else
        {
            transform.position = shootPoint.position;
            transform.rotation = shootPoint.rotation;
        }
    }

    Vector3 ArrowPosition()
    {
        Vector3 graity = new Vector3(0, -9.81f, 0);
        return 0.5f * graity * time * time + V0 * time + P0;
    }

    Vector3 ArrowVelocity()
    {
        Vector3 graity = new Vector3(0, -9.81f, 0);
        return graity * time + V0;
    }
}
