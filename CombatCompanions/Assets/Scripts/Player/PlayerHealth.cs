using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GameEvents.gameEvent.SpawnTextMesh("-" + damage, transform.position, 35, ColorIndex.colors.redCrimson, 1.5f);
        if (health <= 0)
        {
            //Dead
            PlayerEvents.playerEvent.PlayerDied();
            health = 0; //Sorts the UI Bar out if lower than 0
        }

        PlayerEvents.playerEvent.PlayerHealthChanged(health, maxHealth);
    }

    public void RegainHealth(float amount)
    {
        health += amount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        PlayerEvents.playerEvent.PlayerHealthChanged(health, maxHealth);
    }
}
