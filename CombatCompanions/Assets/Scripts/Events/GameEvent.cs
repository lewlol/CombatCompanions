using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent gameEvent;
    private void Awake()
    {
        gameEvent = this;
    }

    public event Action<float> onAddPoints;
    public void AddPoints(float amount)
    {
        if (onAddPoints != null)
        {
            onAddPoints(amount);
        }
    }

    public event Action<float> onRemovePoints;
    public void RemovePoints(float amount)
    {
        if(onRemovePoints != null)
        {
            onRemovePoints(amount);
        }
    }

    public event Action<float> onPointsChanged;
    public void PointsChanged(float amount)
    {
        if(onPointsChanged != null)
        {
            onPointsChanged(amount);
        }
    }

    public event Action onEnemyDied;
    public void EnemyDied()
    {
        if(onEnemyDied != null)
        {
            onEnemyDied();
        }
    }

    public event Action<Vector2, AudioClip> onSpawnSound;
    public void SpawnSound(Vector2 position, AudioClip sound)
    {
        if (onSpawnSound != null)
        {
            onSpawnSound(position, sound);
        }
    }

    public event Action onStartedNextWave;
    public void StartedNextWave()
    {
        if(onStartedNextWave != null)
        {
            onStartedNextWave();
        }
    }

    public event Action<float> onWaveBreakCountdown;
    public void WaveBreakCountdown(float time)
    {
        if (onWaveBreakCountdown != null)
        {
            onWaveBreakCountdown(time);
        }
    }
}
