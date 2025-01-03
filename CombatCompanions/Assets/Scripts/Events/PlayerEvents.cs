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

    //CALLED TO ADD SOULS TO PLAYER
    public event Action<int> onAddSouls;
    public void AddSouls(int amount)
    {
        if(onAddSouls != null)
        {
            onAddSouls(amount);
        }
    }

    //CALLED TO REMOVE SOULS FROM PLAYER
    public event Action<int> OnRemoveSouls;
    public void RemoveSouls(int amount)
    {
        if(OnRemoveSouls != null)
        {
            OnRemoveSouls(amount);
        }
    }

    //THIS IS CALLED WHEN THE SOUL COUNT CHANGES IN ANY WAY
    public event Action<int> onSoulsCountChanged;
    public void SoulsCountChanged(int amount)
    {
        if (onSoulsCountChanged != null)
        {
            onSoulsCountChanged(amount);
        }
    }
}
