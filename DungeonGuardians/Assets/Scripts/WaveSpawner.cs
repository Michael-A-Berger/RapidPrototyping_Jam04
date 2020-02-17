using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    private GridManager gridManager;
    private Transform enemy1SpawnPoint;
    private Transform enemy2SpawnPoint;
    public List<GameObject> enemiesList;

    public float timeBetweenWaves = 10f;
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
        if (enemy1SpawnPoint != null || enemy2SpawnPoint != null)
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
            enemy1SpawnPoint = gridManager.Enemy1Waypoints[0].transform;
            enemy2SpawnPoint = gridManager.Enemy2Waypoints[0].transform;
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
        enemiesList.Add(Instantiate(enemy1Prefab, enemy1SpawnPoint.position, enemy1SpawnPoint.rotation));
        enemiesList.Add(Instantiate(enemy2Prefab, enemy2SpawnPoint.position, enemy2SpawnPoint.rotation));
    }
}
