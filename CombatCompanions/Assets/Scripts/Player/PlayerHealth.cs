using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    private void Awake()
    {
        health = PlayerStats.playerStats.maxHealth;
        PlayerEvent.playerEvent.PlayerHealthChange(PlayerStats.playerStats.maxHealth, health);

        PlayerEvent.playerEvent.onHealPlayer += RestoreHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            PlayerEvent.playerEvent.PlayerDied();
        }

        PlayerEvent.playerEvent.PlayerHealthChange(PlayerStats.playerStats.maxHealth, health);
        GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.hurtSound);
    }

    public void RestoreHealth(float amount)
    {
        health += amount;
        if(health > PlayerStats.playerStats.maxHealth)
        {
            health = PlayerStats.playerStats.maxHealth;
        }

        PlayerEvent.playerEvent.PlayerHealthChange(PlayerStats.playerStats.maxHealth, health);
    }
}
