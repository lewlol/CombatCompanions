using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents gameEvent;
    private void Awake()
    {
        gameEvent = this;
    }

    //CALLED WHEN AN ENEMY DIES
    public event Action onEnemyDied;
    public void EnemyDied()
    {
        if (onEnemyDied != null)
        {
            onEnemyDied();
        }
    }

    //CALLED WHEN A NEW WAVE STARTS
    public event Action<int> onWaveStarted;
    public void WaveStarted(int wave)
    {
        if(onWaveStarted != null)
        {
            onWaveStarted(wave);
        }
    }

    //CALLED WHEN WAVE ENDS
    public event Action onWaveEnded;
    public void WaveEnded()
    {
        if(onWaveEnded != null)
        {
            onWaveEnded();
        }
    }

    //CALLED WHEN THE ENEMIES REMAINING COUNTER CHANGES
    public event Action<int> onEnemiesRemainingChanged;
    public void EnemiesRemainingChanged(int enemiesRemaining)
    {
        if(onEnemiesRemainingChanged != null)
        {
            onEnemiesRemainingChanged(enemiesRemaining);
        }
    }

    //CALLED WHILE THE DELAY COUNTDOWN IS COUNTING DOWN
    public event Action<float> onWaveTimerCountdown;
    public void WaveTimerCountdown(float time)
    {
        if(onWaveTimerCountdown != null)
        {
            onWaveTimerCountdown(time);
        }
    }

    //CALLED WHEN A SOUND IS SPAWNED TO PLAY
    public event Action<Vector2, AudioClip> onSpawnAudio;
    public void SpawnAudio(Vector2 position, AudioClip clip)
    {
        if(onSpawnAudio != null)
        {
            onSpawnAudio(position, clip);
        }
    }

    //CALLED WHEN A TEXT MESH IS SENT TO BE SPAWNED
    public event Action<string, Vector2, int, Color, float> onSpawnTextMesh;
    public void SpawnTextMesh(string text, Vector2 spawnLocation, int size, Color color, float time)
    {
        if (onSpawnTextMesh != null)
        {
            onSpawnTextMesh(text, spawnLocation, size, color, time);
        }
    }

    public event Action onOpenMerchantUI;
    public void OpenMerchantUI()
    {
        if(onOpenMerchantUI != null)
        {
            onOpenMerchantUI();
        }
    }

    public event Action onCloseMerchantUI;
    public void CloseMerchantUI()
    {
        if(onCloseMerchantUI != null)
        {
            onCloseMerchantUI();
        }
    }
}
