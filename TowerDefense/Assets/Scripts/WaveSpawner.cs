using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Space(25f)]
    [Header("Stats")]

    [SerializeField] [Range(0, 5)]     private float delayBetweenEnemies = 1f;
    [SerializeField] [Range(0,100)]    private float timeBetweenWaves = 5f;
    [SerializeField] [Range(0,10)]     private float countDown = 2f;
    [SerializeField] [Range(0,1000)]   private int waveIndex = 0;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveCountdownTimer;

    [Space(25f)]
    [Header("Others")]


    [Space(25f)]
    [Header("References")]

    [SerializeField] Transform enemyPrefab;


    void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        waveCountdownTimer.text = countDown.ToString("une nouvelle vague arrive dans : " + Mathf.Round(countDown));
    }

    //Begin a new wave
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(delayBetweenEnemies);
        }
    }

    //Spawn an enemy
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
