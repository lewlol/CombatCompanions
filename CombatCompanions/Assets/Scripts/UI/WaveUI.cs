using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    public TextMeshProUGUI currentWaveUI;
    int w;

    public TextMeshProUGUI waveCountdownUI;
    private void Awake()
    {
        GameEvent.gameEvent.onStartedNextWave += IncreaseWaveCounter;
        GameEvent.gameEvent.onWaveBreakCountdown += WaveTimer;
    }

    public void IncreaseWaveCounter()
    {
        w++;
        currentWaveUI.text = "Wave " + w.ToString();
        waveCountdownUI.enabled = false;
    }

    public void WaveTimer(float time)
    {
        waveCountdownUI.enabled = true;
        waveCountdownUI.text = "Time Until Next Wave " + time.ToString("F1");
    }
}
