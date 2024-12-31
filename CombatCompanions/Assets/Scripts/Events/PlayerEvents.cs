using System;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public static PlayerEvents playerEvent;

    private void Awake()
    {
        playerEvent = this;
    }

    //THIS IS CALLED WHEN THE PLAYER'S HEALTH VALUE IS CHANGED
    public event Action<float, float> onPlayerHealthChanged;
    public void PlayerHealthChanged(float health, float maxHealth)
    {
        if (onPlayerHealthChanged != null)
        {
            onPlayerHealthChanged(health, maxHealth);
        }
    }

    //THIS IS CALLED WHEN THE PLAYER DIES
    public event Action onPlayerDied;
    public void PlayerDied()
    {
        if(onPlayerDied != null)
        {
            onPlayerDied();
        }
    }
}
