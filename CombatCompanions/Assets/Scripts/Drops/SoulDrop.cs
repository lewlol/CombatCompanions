using UnityEngine;

public class SoulDrop : MonoBehaviour
{
    public int amount;
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerEvents.playerEvent.AddSouls(amount);
            GameEvents.gameEvent.SpawnAudio(transform.position, sound);
            GameEvents.gameEvent.SpawnTextMesh("+" + amount.ToString() + " Soul", transform.position + new Vector3(0, 1f, 0), 30, ColorIndex.colors.blueLight, 1f);
            Destroy(gameObject);
        }
    }
}
