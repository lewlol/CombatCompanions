using TMPro;
using UnityEngine;

public class SoulsUI : MonoBehaviour
{
    public TextMeshProUGUI soulCounter;

    private void Awake()
    {
        PlayerEvents.playerEvent.onSoulsCountChanged += SoulCountChanged;
    }
    public void SoulCountChanged(int amount)
    {
        soulCounter.text = amount.ToString() + " Souls";
    }
}
