using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public float rotSpeed;
    public int rotationIndex;
    public bool rotationCompleted = false;

    List<Quaternion> rotations1 = new List<Quaternion>();
    List<Quaternion> rotations2 = new List<Quaternion>();
    void Start()
    {
        DefineRotations1();
        DefineRotations2();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!rotationCompleted)
        {
            ChangeRotation(rotations2);
        }
        
    }

    void DefineRotations1()
    {
        Vector3 r = new Vector3(1, 0, 0);
        Vector3 u = new Vector3(0, 1, 0);
        Vector3 f = new Vector3(0, 0, 1);
        rotations1.Add(Quaternion.LookRotation(f, -r));
        rotations1.Add(Quaternion.LookRotation(u, -r));
        rotations1.Add(Quaternion.LookRotation(u, -f));
        rotations1.Add(Quaternion.LookRotation(-r, -f));
        rotations1.Add(Quaternion.LookRotation(-r, u));
        rotations1.Add(Quaternion.identity);
    }


    void DefineRotations2()
    {
        Vector3 r = new Vector3(1, 0, 0);
        Vector3 u = new Vector3(0, 1, 0);
        Vector3 f = new Vector3(0, 0, 1);
        rotations2.Add(Quaternion.LookRotation(f, -r));
        rotations2.Add(Quaternion.LookRotation(-r, -u));
        rotations2.Add(Quaternion.LookRotation(-r, f));
        rotations2.Add(Quaternion.LookRotation(u, f));
        rotations2.Add(Quaternion.LookRotation(f, -r));
        rotations2.Add(Quaternion.LookRotation(-u, -r));
    }

    void ChangeRotation(List<Quaternion> rotations)
    {
        float dt = Time.fixedDeltaTime;
        Quaternion targetRotation = rotations[rotationIndex];
        if (transform.rotation != targetRotation && rotationIndex < rotations.Count - 1)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotations[rotationIndex], rotSpeed * dt);
        }
        else
        {
            transform.rotation = targetRotation;
            rotationIndex++;
            if (rotationIndex == rotations.Count) { rotationCompleted = true; }
        }
    }

}
