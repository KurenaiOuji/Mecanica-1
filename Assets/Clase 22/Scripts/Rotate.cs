using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] Vector3 rotationDiretion;

    void Update()
    {
        transform.Rotate(rotationSpeed * rotationDiretion * Time.deltaTime);
    }
}
