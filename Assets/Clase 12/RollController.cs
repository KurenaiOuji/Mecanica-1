using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    public float angularSpeed;
    private float xAngle;

    void Update()
    {
        float vInput = Input.GetAxis("HorizontalRoll");
        xAngle += angularSpeed * vInput * Time.deltaTime;
        transform.rotation = Quaternion.Euler(xAngle, 0, 0);
    }
}
