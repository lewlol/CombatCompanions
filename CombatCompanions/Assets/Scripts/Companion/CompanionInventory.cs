using System.Collections.Generic;
using UnityEngine;
public class CompanionInventory : MonoBehaviour
{
    public List<Companion> companions = new List<Companion>();

    public void AddCompanion(Companion companion)
    {
        companions.Add(companion);
    }

    public void RemoveCompanion(Companion companion)
    {
        companions.Remove(companion);
    }
}
