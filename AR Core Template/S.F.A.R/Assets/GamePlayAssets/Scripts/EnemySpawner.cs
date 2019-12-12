using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int enemyNumer = 1;
    public float timeBetweenWave = 1f;
    float currentTime;
    public float timeBetweenEnemy = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {

    }
    IEnumerator Spawn(int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
                Instantiate(Enemy, transform.GetChild(Random.Range(0, transform.childCount)).transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemy);
        }
    }
    IEnumerator SpawnEnemy()
    {
        StartCoroutine(Spawn(enemyNumer));
        yield return new WaitForSeconds(timeBetweenWave);
        enemyNumer += 1;
        timeBetweenWave += 1f;
        StartCoroutine(SpawnEnemy());
    }
}
