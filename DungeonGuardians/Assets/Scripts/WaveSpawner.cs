using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GridManager gridManager;
    private Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPoint != null)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            countdown -= Time.deltaTime;
        }
        else
        {
            spawnPoint = gridManager.EnemyWaypoints[0].transform;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        waveNum++;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
