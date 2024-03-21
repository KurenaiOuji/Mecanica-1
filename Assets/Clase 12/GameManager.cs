using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float time;
    public GameObject Scene1;
    public GameObject Scene2;

    public bool P1, P2, P3 = true;

    public bool PlayersAlive = true;

    void Start()
    {
        Scene1.SetActive(false);
        Scene2.SetActive(false);
    }

    void Update()
    {
        time -= Time.deltaTime;

        if ((P1 == false) && (P2 == false) && (P3 == false))
        {
            PlayersAlive = false;
        }

        if (time < 0)
        {
            Scene2.SetActive(true);
            Time.timeScale = 0;
        }

        if(PlayersAlive == false)
        {
            Scene1.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("P1"))
        {
            P1 = false;
        }

        if (collider.CompareTag("P2"))
        {
            P2 = false;
        }

        if (collider.CompareTag("P3"))
        {
            P3 = false;
        }
    }
}
