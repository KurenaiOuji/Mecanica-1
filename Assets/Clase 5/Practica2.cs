using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practica2 : MonoBehaviour
{
    public Transform platformA;
    public Transform platformB;

    public float travelTime, speed, time;

    void Start()
    {
        transform.position = platformA.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAB = (platformB.position - platformA.position).magnitude;
        speed = distanceAB / travelTime;
        Vector3 direction = (platformB.position - platformA.position).normalized;
        Vector3 P0 = platformA.position;
        Vector3 V0 = speed * direction;

        time += Time.deltaTime;
        transform.position = Kinematics.MovimientoRectilineoUniforme(time, P0, V0);

    }
}
