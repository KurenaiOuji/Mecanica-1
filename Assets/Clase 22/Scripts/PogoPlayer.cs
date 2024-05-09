using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoPlayer : MonoBehaviour
{
    public float forceImpulse, jumpImpulse, gravity;
    public string hInputName, vInputName;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        Physics.gravity = gravity * Vector3.up;
        float hInput = Input.GetAxis(hInputName);
        float vInput = Input.GetAxis(vInputName);
        Vector3 direction = new Vector3(hInput, 0, vInput).normalized;
        rb.AddForce(forceImpulse * direction * Time.deltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Base"))
        {
            rb.AddForce(jumpImpulse * transform.up, ForceMode.Impulse);
        }
    }
}
