using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoosBallPlayer : MonoBehaviour
{
    public string verticalInputName;
    public float impulse, drag;
    public Rigidbody cubeRB;
    float verticalInput;

    private void Update()
    {
        verticalInput = Input.GetAxisRaw(verticalInputName);
    }

    private void FixedUpdate()
    {
        cubeRB.drag = drag;
        Vector3 force = -impulse * Vector3.right * verticalInput;
        cubeRB.AddForce(force, ForceMode.VelocityChange);
    }
}
