using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public float minSpeedX, minSpeedZ, maxAbsoluteSpeed;
    public float speedIncrement;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomVector = Random.onUnitSphere;
        randomVector.y = 0;
        rb.velocity = randomVector.normalized;
    }

    private void FixedUpdate()
    {
        Limitvelocity();
    }

    void Limitvelocity()
    {
        //Vector3 velocity = rb.velocity;
        float singVx = Mathf.Sign(rb.velocity.x);
        float singVz = Mathf.Sign(rb.velocity.z);

        if (Mathf.Abs(rb.velocity.z) < minSpeedZ)
            rb.velocity = new Vector3(rb.velocity.x, 0, singVz * minSpeedZ);

        if(rb.velocity.magnitude > maxAbsoluteSpeed)
            rb.velocity = maxAbsoluteSpeed * (rb.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("FoosballPlayer"))
        {
            minSpeedX += speedIncrement;
            minSpeedZ += speedIncrement;
        }
    }
}
