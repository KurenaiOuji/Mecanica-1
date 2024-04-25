using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RK2Motion : MonoBehaviour
{
    public Vector3 Pcurrent, Vcurrent;
    public float m;
    private Vector3 Pmiddle, Vmiddle, Pnext, Vnext;

    void Start()
    {
        transform.position = Pcurrent;
    }

    private void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;
        Pmiddle = Pcurrent + 0.5f * dt * Vcurrent;
        Vmiddle = Vcurrent + 0.5f * dt * F(Pcurrent, Vcurrent) / m;

        Pnext = Pmiddle + dt * Vmiddle;
        Vnext = Vmiddle + dt * F(Pmiddle, Vmiddle);

        transform.position = Pnext;
        Pcurrent = Pnext;
        Vcurrent = Vnext;
    }

    Vector3 F(Vector3 P, Vector3 V)
    {
        //Vector3 result = m * new Vector3(0, -9.81f, 0);
        Vector3 result = -P;
        return result;
    }
}
