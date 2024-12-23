using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    private void Awake()
    {
        GameEvent.gameEvent.onPointsChanged += EditPointsText;
    }
    public void EditPointsText(float amount)
    {
        pointsText.text = amount.ToString();
    }
}
