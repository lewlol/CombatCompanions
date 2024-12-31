using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave;

    public int baseEnemyCount;
    public float midWaveTime;
    int totalEnemies;
    int enemiesRemaining;

    public Transform[] spawnPositions;
    public GameObject enemy;

    bool midWave;
    float c;
    private void Awake()
    {
        GameEvents.gameEvent.onEnemyDied += EnemyDied;
        c = midWaveTime;
        midWave = true;
    }

    public void StartWave()
    {
        midWave = false;
        c = midWaveTime;

        currentWave++;
        totalEnemies = baseEnemyCount + currentWave;
        enemiesRemaining = totalEnemies;

        GameEvents.gameEvent.WaveStarted(currentWave);
        GameEvents.gameEvent.EnemiesRemainingChanged(enemiesRemaining);

        for (int i = 0; i < totalEnemies; i++)
        {
            float timeTillSpawn = Random.Range(0.1f, 3f);
            Invoke("SpawnEnemy", timeTillSpawn);
        }
    }

    private void SpawnEnemy()
    {
        int pos = Random.Range(0, spawnPositions.Length);
        Transform activePos = spawnPositions[pos];
        GameObject newEnemy = Instantiate(enemy, activePos.position, Quaternion.identity);
    }

    public void EnemyDied()
    {
        enemiesRemaining--;
        GameEvents.gameEvent.EnemiesRemainingChanged(enemiesRemaining);
        if(enemiesRemaining == 0)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        midWave = true;
    }

    private void Update()
    {
        if (midWave)
        {
            float countdown = c -= Time.deltaTime;
            GameEvents.gameEvent.WaveTimerCountdown(countdown);
            if(countdown <= 0)
            {
                StartWave();
            }
        }
    }
}
