using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    private void Awake()
    {
        playerStats = this;
        SetBaseStats();
    }

    //Base Stat Values
    float baseMaxHealth = 15;
    float baseSpeed = 5;

    [Header("Stats")]
    public float maxHealth;
    public float speed;

    public void EditStat(StatName statName, float amount, bool addition)
    {
        if (!addition)
            amount = -amount;

        switch (statName)
        {
            case StatName.MAXHEALTH:
                maxHealth += amount;
                break;
            case StatName.SPEED:
                speed += amount;
                break;
        }
    }

    private void SetBaseStats()
    {
        maxHealth = baseMaxHealth;
        speed = baseSpeed;
    }
}

public enum StatName 
{
    MAXHEALTH,
    SPEED,
}

