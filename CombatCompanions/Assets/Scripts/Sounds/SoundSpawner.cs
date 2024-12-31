using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    public GameObject soundOBJ;

    private void Awake()
    {
        GameEvents.gameEvent.onSpawnAudio += SpawnSoundOBJ;
    }

    public void SpawnSoundOBJ(Vector2 position, AudioClip soundClip)
    {
        GameObject newSoundOBJ = Instantiate(soundOBJ, position, Quaternion.identity);
        newSoundOBJ.GetComponent<AudioSource>().clip = soundClip;
        newSoundOBJ.GetComponent<AudioSource>().Play();

        Destroy(newSoundOBJ, soundClip.length + 0.5f);
    }
}
