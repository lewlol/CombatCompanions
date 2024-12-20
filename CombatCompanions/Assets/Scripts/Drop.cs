using UnityEngine;

public class Drop : MonoBehaviour
{
    public DropType dType;
    public float amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (dType)
            {
                case DropType.health:
                    PlayerEvent.playerEvent.HealPlayer(amount);
                    GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.healthPickup);
                    break;
                case DropType.soul:
                    GameEvent.gameEvent.AddPoints(amount);
                    GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.soulPickup);
                    break;
            }

            Destroy(gameObject);
        }
    }
}

public enum DropType
{
    health, soul
}
