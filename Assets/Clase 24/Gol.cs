using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gol : MonoBehaviour
{
    public bool P1, P2;
    public TextMeshProUGUI TextP1, TextP2;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("KoopaShell") && P1)
        {

        }
    }
}
