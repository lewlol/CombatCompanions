using UnityEngine;

public class DeathScreenUI : MonoBehaviour
{
    public GameObject deathScreen;

    private void Awake()
    {
        PlayerEvents.playerEvent.onPlayerDied += EnableUI;
    }

    public void EnableUI()
    {
        deathScreen.SetActive(true);
    }
}
