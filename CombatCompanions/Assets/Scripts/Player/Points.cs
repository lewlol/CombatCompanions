using UnityEngine;

public class Points : MonoBehaviour
{
    public float points;

    private void Awake()
    {
        GameEvent.gameEvent.onAddPoints += AddPoints;
        GameEvent.gameEvent.onRemovePoints += RemovePoints;
    }
    public void AddPoints(float amount)
    {
        points += amount;
        GameEvent.gameEvent.PointsChanged(points);
    }

    public void RemovePoints(float amount)
    {
        points -= amount;
        GameEvent.gameEvent.PointsChanged(points);
    }
}
