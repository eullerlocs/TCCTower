using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float TimeBetweenWaves = 5f;
    private float countdown = 5f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
      if (countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.waves++;

        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

       
    }

    void spawnEnemy()
    {
        Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }



}
