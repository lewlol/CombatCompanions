using UnityEngine;

public class SoundLib : MonoBehaviour
{
    public static SoundLib sounds;

    private void Awake()
    {
        sounds = this;
    }

    public AudioClip attackSound;
    public AudioClip shootSound;
    public AudioClip hurtSound;

    [Space]
    public AudioClip buttonClick;

    [Space]
    public AudioClip healthPickup;
    public AudioClip soulPickup;
}
