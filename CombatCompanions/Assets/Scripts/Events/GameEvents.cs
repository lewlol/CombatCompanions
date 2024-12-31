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
}
