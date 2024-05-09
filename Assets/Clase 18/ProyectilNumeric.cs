using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilNumeric : MonoBehaviour
{
    public Vector3 Pcurrent, Vcurrent;
    public float m;
    Vector3 F, Pnext, Vnext;

    private void Update()
    {
        F = m * new Vector3(0f, -9.81f, 0f);
        float dt = Time.deltaTime;
        Pnext = Pcurrent + dt * Vcurrent;
        Vnext = Vcurrent + dt * F/m;

        transform.position = Pnext;
        Pcurrent = Pnext;
        Vcurrent = Vnext;
    }
}
