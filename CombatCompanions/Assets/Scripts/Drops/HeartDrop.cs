using UnityEngine;

public class HeartDrop : MonoBehaviour
{
    public float amount;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().RegainHealth(amount);
            GameEvents.gameEvent.SpawnAudio(transform.position, sound);
            GameEvents.gameEvent.SpawnTextMesh("+" + amount.ToString() + " Health", transform.position + new Vector3(0, 1f, 0), 30, ColorIndex.colors.redLight, 1f);
            Destroy(gameObject);
        }
    }
}
