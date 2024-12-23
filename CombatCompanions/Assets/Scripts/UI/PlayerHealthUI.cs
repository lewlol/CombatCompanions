using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;

    private void Awake()
    {
        PlayerEvent.playerEvent.onPlayerHealthChange += ChangeSlider;
    }

    public void ChangeSlider(float maxHealth, float health)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;

        healthText.text = health + " / " + maxHealth;
    }
}
