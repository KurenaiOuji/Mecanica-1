using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P1"))
        {
           P1.gameObject.SetActive(true);
        }
        else if(other.CompareTag("P2"))
        {
            P2.gameObject.SetActive(true);
        }
    }

}
