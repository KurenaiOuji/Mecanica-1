using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool P1, P2, P3, P4;

    public GameObject P1Win;
    public GameObject P2Win;
    public GameObject P3Win;
    public GameObject P4Win;

    void Start()
    {
        Time.timeScale = 1.0f;

        P1 = false;
        P2 = false;
        P3 = false;
        P4 = false;

        P1Win.SetActive(false);
        P2Win.SetActive(false);
        P3Win.SetActive(false);
        P4Win.SetActive(false);
    }

    private void Update()
    {
        changescene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("P1"))
        {
            P1 = true;
        }

        if (other.CompareTag("P2"))
        {
            P2 = true;
        }

        if (other.CompareTag("P3"))
        {
            P3 = true;
        }

        if (other.CompareTag("P4"))
        {
            P4 = true;
        }
    }

    void changescene()
    {
        if(P2 && P3 && P4)
        {
            P1Win.SetActive(true);
            Time.timeScale = 0;
        }

        if (P1 && P3 && P4)
        {
            P2Win.SetActive(true);
            Time.timeScale = 0;
        }

        if (P1 && P2 && P4)
        {
            P3Win.SetActive(true);
            Time.timeScale = 0;
        }

        if (P1 && P2 && P3)
        {
            P4Win.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
