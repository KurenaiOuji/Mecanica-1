using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10f;
    bool inGround;
    public float _gravity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inGround = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inGround == true)
        {
            Jump();
        }
        Physics.gravity = _gravity * Vector3.up;
    }

    void Jump()
    {
        inGround = false;
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inGround = true;
        }
    }
}
