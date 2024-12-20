using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public int currentWave;
    public int baseEnemyCount;

    public Enemy[] enemies;
    public Transform[] spawnPositions;

    float enemiesAlive;
    float waveEnemyAmount;

    bool midWave;
    public float waveBreakTime;
    float c;
    private void Awake()
    {
        GameEvent.gameEvent.onEnemyDied += EnemyDied;
        StartRound();
    }
    public void StartRound()
    {
        midWave = false;
        c = waveBreakTime;

        currentWave++;
        waveEnemyAmount = baseEnemyCount + currentWave;
        enemiesAlive = waveEnemyAmount;

        GameEvent.gameEvent.StartedNextWave();
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for(int e = 0; e < waveEnemyAmount; e++)
        {
            int i = Random.Range(0, enemies.Length);
            Enemy enemy = enemies[i];

            int s = Random.Range(0, spawnPositions.Length);
            Vector2 spawnPosition = spawnPositions[s].position;
            GameObject newEnemyOBJ = Instantiate(enemy.enemyPrefab, spawnPosition, Quaternion.identity);

            Debug.Log("Enemy Spawned");
        }
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        if(enemiesAlive == 0)
        {
            midWave = true;
        }
    }

    private void Update()
    {
        if (midWave)
        {
            float countDown = c -= Time.deltaTime;
            GameEvent.gameEvent.WaveBreakCountdown(countDown);
            if(countDown <= 0)
            {
                StartRound();
            }
        }
    }
}
