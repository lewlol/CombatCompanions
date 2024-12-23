using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent gameEvent;
    public static GameObject manager;
    private void Awake()
    {
        gameEvent = this;
        if(manager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = gameObject;
            DontDestroyOnLoad(gameObject);
        }
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

    public event Action onWaveEnded;
    public void WaveEnded()
    {
        if(onWaveEnded != null)
        {
            onWaveEnded();
        }
    }

    public event Action<Companion> onSetActiveCompanion;
    public void SetActiveCompanion(Companion companion)
    {
        if(onSetActiveCompanion != null)
        {
            onSetActiveCompanion(companion);
        }
    }

    public event Action onStartedGame;
    public void StartedGame()
    {
        if(onStartedGame != null)
        {
            onStartedGame();
        }
    }
}
