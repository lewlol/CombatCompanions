using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Awake()
    {
        PlayerEvent.playerEvent.onPlayerDied += EnableGameOverUI;
    }

    public void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
}
