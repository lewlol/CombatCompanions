using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI currentWaveText;
    public TextMeshProUGUI enemiesRemainingText;

    private void Awake()
    {
        GameEvents.gameEvent.onWaveStarted += ChangeCurrentWaveText;
        GameEvents.gameEvent.onEnemiesRemainingChanged += ChangeEnemiesRemainingText;
        GameEvents.gameEvent.onWaveTimerCountdown += WaveDelayCountDown;
    }
    public void ChangeCurrentWaveText(int wave)
    {
        currentWaveText.text = "Wave: " + wave.ToString();
    }

    public void ChangeEnemiesRemainingText(int enemiesLeft)
    {
        enemiesRemainingText.text = "Enemies Left: " + enemiesLeft.ToString();
    }

    public void WaveDelayCountDown(float time)
    {
        enemiesRemainingText.text = time.ToString("F1");
    }
}
