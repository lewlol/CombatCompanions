using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Enemy enemy;
    public float health;

    private void Awake()
    {
        health = enemy.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        GameEvents.gameEvent.SpawnTextMesh("-" + damage, transform.position, 25, Color.red, 1.5f);
        if(health <= 0)
        {
            GameEvents.gameEvent.EnemyDied();
            Destroy(gameObject);
        }
    }
}
