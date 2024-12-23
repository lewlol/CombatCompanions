using System;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    public static PlayerEvent playerEvent;
    private void Awake()
    {
        playerEvent = this;
    }

    public event Action<float, float> onPlayerHealthChange;
    public void PlayerHealthChange(float maxHealth, float health)
    {
        if (onPlayerHealthChange != null)
        {
            onPlayerHealthChange(maxHealth, health);
        }
    }

    public event Action onPlayerDied;
    public void PlayerDied()
    {
        if(onPlayerDied != null)
        {
            onPlayerDied();
        }
    }

    public event Action<float> onHealPlayer;
    public void HealPlayer(float amount)
    {
        if(onHealPlayer != null)
        {
            onHealPlayer(amount);
        }
    }
}
