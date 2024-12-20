using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public GameObject soundOBJ;

    private void Awake()
    {
        GameEvent.gameEvent.onSpawnSound += SpawnSoundOBJ;
    }
    public void SpawnSoundOBJ(Vector2 position, AudioClip sound)
    {
        GameObject sOBJ = Instantiate(soundOBJ, position, Quaternion.identity);
        sOBJ.GetComponent<AudioSource>().clip = sound;

        Destroy(sOBJ, sound.length + 0.5f);

        sOBJ.GetComponent<AudioSource>().Play();
    }
}
