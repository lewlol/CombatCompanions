using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthBar;

    private void Awake()
    {
        PlayerEvents.playerEvent.onPlayerHealthChanged += ChangeSlider;
    }

    public void ChangeSlider(float health, float maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }
}
