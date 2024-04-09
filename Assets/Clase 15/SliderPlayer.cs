using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlayer : MonoBehaviour
{
    public string horizontalInputName, verticalInputName;
    public float forceMagnitude, torqueMagnitude;
    public LayerMask bowlLayer;
    private Rigidbody rb;

    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void FixedUpdate()
    {
        MovementControl();
        RotationRectification();

    }

    void MovementControl()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis(horizontalInputName);
        float vInput = Input.GetAxis(verticalInputName);

        Vector3 torque = torqueMagnitude * transform.up * hInput * dt;
        Vector3 force = forceMagnitude * transform.forward * vInput * dt;
        rb.AddTorque(torque, ForceMode.Force);
        rb.AddForce(force, ForceMode.Force);
    }

    void RotationRectification()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, bowlLayer))
        {
            Vector3 newUp = hit.normal;
            Vector3 newForward = transform.forward - Vector3.Dot(transform.forward, newUp) * newUp;
            transform.rotation = Quaternion.LookRotation(newForward, newUp);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowlLimit"))
        {
            float forceMagnitude = 1;
            float torqueMagnitude = 1;
            Vector3 force = forceMagnitude * (transform.position).normalized;
            rb.AddForce(force, ForceMode.Impulse);
            Vector3 torque = torqueMagnitude * Random.onUnitSphere;
            rb.AddTorque(torque, ForceMode.Impulse);

            audioSource.Play();
        }

        if (other.CompareTag("Limit"))
        {
            Destroy(this.gameObject);
        }
    }
}
