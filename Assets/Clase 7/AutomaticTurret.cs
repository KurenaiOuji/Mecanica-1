using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AutomaticTurret : MonoBehaviour
{
    public Transform target;
    public Transform turretAxisY;
    public Transform turretAxisX;
    public Transform shootPoint;

    public GameObject bulletPrefab;

    public float rotSpeed;
    private float V0;
    private float g = 9.81f;

    void Update()
    {
        TuretRotation();
        AimRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 p0 = shootPoint.position;
        Vector3 v0 = V0 * shootPoint.forward;

        Quaternion r0 = shootPoint.rotation;

        GameObject bullet = Instantiate(bulletPrefab, p0, r0);

        bullet.GetComponent<KinematicBullet>().P0 = p0;
        bullet.GetComponent<KinematicBullet>().V0 = v0;
    }

    void TuretRotation()
    {
        float dt = Time.deltaTime;
        Quaternion newRotation = Quaternion.LookRotation(TargetDirection(), Vector3.up);
        turretAxisY.localRotation = Quaternion.Slerp(turretAxisY.localRotation, newRotation, rotSpeed * dt);
    }

    void AimRotation()
    {
        Vector2 angles = Angles();
        turretAxisX.localRotation = Quaternion.Euler(-angles.x, 0, 0);
    }

    Vector3 TargetDirection()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        return direction;
    }

    Vector2 Angles()
    {
        Vector2 delta = Delta();
        float dx = delta.x;
        float dy = delta.y;
        float tanA = dy / dx;
        float secA = Mathf.Sqrt(1 + tanA * tanA);
        V0 = Mathf.Sqrt(g * dx * (tanA + secA)) + 1;

        float U = V0 * V0 / (dx * g);
        float w1 = U + Mathf.Sqrt(U * U - 2 * tanA * U - 1);
        float w2 = U - Mathf.Sqrt(U * U - 2 * tanA * U - 1);

        float angle1 = Mathf.Rad2Deg * Mathf.Atan(w1);
        float angle2 = Mathf.Rad2Deg * Mathf.Atan(w2);

        return new Vector2(angle1, angle2);
    }

    Vector3 Delta()
    {
        Vector3 relativePosition = target.position - shootPoint.position;
        Vector2 relativePosition2D = new Vector2(relativePosition.x, relativePosition.z);

        float dx = relativePosition2D.magnitude;
        float dy = relativePosition.y;

        return new Vector2(dx, dy);
    }
}
