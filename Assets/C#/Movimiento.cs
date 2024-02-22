using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float time;

    void Update()
    {
        time += Time.deltaTime;
        transform.position = PositionFunction(time);
    }

    Vector3 PositionFunction(float time)
    {
        float x = 3 * time - 5;
        float y = -2 * time + 10;
        float z = 4 * time;

        return new Vector3(x, y, z);
    }
}
