using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipManager : MonoBehaviour
{
    public int numEnemies;
    public GameObject enemyPrefab;

    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);

            enemy.GetComponent<EnemyShip>().r = Random.Range(100, 500f);
            enemy.GetComponent<EnemyShip>().w0 = Random.Range(-0.75f, 0.75f);
            enemy.GetComponent<EnemyShip>().w1 = Random.Range(-0.75f, 0.75f);
            enemy.GetComponent<EnemyShip>().f0 = Random.Range(0f, 2 * Mathf.PI);
            enemy.GetComponent<EnemyShip>().f1 = Random.Range(0f, 2 * Mathf.PI);
            enemy.GetComponent<EnemyShip>().h = Random.Range(250, 500f);

        }   
    }
}
