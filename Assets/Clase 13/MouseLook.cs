using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float rotationSpeed, verticalRotationLimit;
    public Transform playerCamera;

    private float xAngle, yAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        float verticalInput = Input.GetAxis("Mouse Y");
        float horizontalInput = Input.GetAxis("Mouse X");

        // Movimiento Vertical
        xAngle -= verticalInput * rotationSpeed * dt;
        xAngle = Mathf.Clamp(xAngle, -verticalRotationLimit, verticalRotationLimit);
        playerCamera.localRotation = Quaternion.Euler(xAngle, 0, 0);

        // Movimiento Horizontal
        yAngle += horizontalInput * rotationSpeed * dt;
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
    }
}

