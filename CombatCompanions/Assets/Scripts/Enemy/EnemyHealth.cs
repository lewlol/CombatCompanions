using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public Enemy enemy;
    private void Awake()
    {
        health = enemy.maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            GameEvent.gameEvent.AddPoints(enemy.points);
            GameEvent.gameEvent.EnemyDied();

            //Drops
            float dChance = Random.Range(0, 100.001f);
            foreach(PossibleDrop pd in enemy.drops)
            {
                if(dChance <= pd.dropChance)
                {
                    Vector3 offset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
                    GameObject drop = Instantiate(pd.drop, transform.position + offset, Quaternion.identity);
                }
            }

            Destroy(gameObject);
        }

        GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.hurtSound);
    }
}
