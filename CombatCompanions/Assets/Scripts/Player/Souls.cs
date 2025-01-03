using UnityEngine;

public class Souls : MonoBehaviour
{
    public static int souls;

    private void Awake()
    {
        PlayerEvents.playerEvent.onAddSouls += AddSouls;
        PlayerEvents.playerEvent.OnRemoveSouls += RemoveSouls;
    }
    public void AddSouls(int amount)
    {
        souls += amount;
        PlayerEvents.playerEvent.SoulsCountChanged(souls);
    }

    public void RemoveSouls(int amount)
    {
        souls -= amount;
        PlayerEvents.playerEvent.SoulsCountChanged(souls);
    }

    public static bool CheckSoulCount(int amount)
    {
        if(souls >= amount) {
            return true; }
        else {
            return false; }
    }
}
