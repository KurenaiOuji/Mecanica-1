using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practica1 : MonoBehaviour
{
    public Vector3 initialPosition, initialVelocity;
    public GameObject particlePrefab;
    public int Num;

    void Update()
    {
        Num = Random.Range(0, 50);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i <= Num; i++)
            {
                GameObject particle = Instantiate(particlePrefab, initialPosition, Quaternion.identity);
                initialPosition = Random.insideUnitSphere;
                initialVelocity = particle.GetComponent<Particle>().V0 = initialVelocity;
                Destroy(particle, 8f);
            }
        }
        /* Random.onUnitSphere = true;
        Random.insideUnitSphere = true; */
    }
}
