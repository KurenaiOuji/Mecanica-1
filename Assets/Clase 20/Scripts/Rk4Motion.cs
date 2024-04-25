using UnityEngine;

public class Rk4Motion : MonoBehaviour
{
    public Vector2 Pcurrent, VCurrent;
    public float m;
    private Vector4 Qcurrent, Qnext, k1, k2, k3, k4;

    void Start()
    {
        Qcurrent = new Vector4(Pcurrent.x, Pcurrent.y, VCurrent.x, VCurrent.y); ;
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        k1 = S(Qcurrent);
        k2 = S(Qcurrent + 0.5f * dt * k1);
        k3 = S(Qcurrent + 0.5f * dt * k2);
        k4 = S(Qcurrent + dt * k3);

        Qnext = Qcurrent + dt * (k1 + 2 * k2 + 2 * k3 + k4) / 6f;
        transform.position = new Vector3(Qnext.x, Qnext.y);

        Qcurrent = Qnext;
    }

    Vector4 S(Vector4 q)
    {
        Vector2 p = new Vector2(q.x, q.y);
        Vector2 v = new Vector2(q.z, q.w);

        float pMagnitude = p.magnitude;
        Vector2 f = -p / Mathf.Pow(pMagnitude, 3f);

        Vector4 result = new Vector4(v.x, v.y, f.x, f.y);
        return result;
    }
}
