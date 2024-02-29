using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public Vector3 initialPosition, initialVelocity;
    public GameObject particlePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject particle = Instantiate(particlePrefab, initialPosition, Quaternion.identity);
            particle.GetComponent<Particle>().P0 = initialPosition;
            particle.GetComponent<Particle>().V0 = initialVelocity;
            Destroy(particle, 10f);
        }
        /* Random.onUnitSphere = true;
        Random.insideUnitSphere = true; */
    }
}
