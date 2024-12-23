using UnityEngine;

public class CompUI : MonoBehaviour
{
    public Companion companion;
    public void SetActiveCompanion()
    {
        GameEvent.gameEvent.SetActiveCompanion(companion);
    }
}
