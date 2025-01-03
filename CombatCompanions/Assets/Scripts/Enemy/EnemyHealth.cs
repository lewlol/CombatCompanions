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
        GameEvents.gameEvent.SpawnAudio(transform.position, enemy.damagedSound);
        GameEvents.gameEvent.SpawnTextMesh("-" + damage, transform.position, 35, ColorIndex.colors.redCrimson, 1.5f);
        if(health <= 0)
        {
            //Drops
            float dropChance = Random.Range(0, 1.0001f);
            if(dropChance <= enemy.dropChance)
            {
                int rDrop = Random.Range(0, enemy.drops.Length);
                GameObject newDrop = Instantiate(enemy.drops[rDrop], transform.position, Quaternion.identity);
            }

            GameEvents.gameEvent.EnemyDied();
            Destroy(gameObject);
        }
    }
}
