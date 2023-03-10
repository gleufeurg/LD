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
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        waveCountdownTimer.text = string.Format(/*"une nouvelle vague arrive dans : " +*/ "{0:00.00}", countDown);
    }

    //Begin a new wave
    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
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
