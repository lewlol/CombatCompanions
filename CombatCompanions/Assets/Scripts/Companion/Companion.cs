using UnityEngine;

[CreateAssetMenu(menuName = "Companion")]
public class Companion : ScriptableObject
{
    [Header("Companion Info")]
    public string CompanionName;


    [Header("Companion Generic Stats")]
    public float speed;

    [Header("Companion Combat Stats")]
    public AttackType attackType;
    public float damage;
    public float attackDelay;
    public float attackRange;

    [Space]
    public float projectileSpeed;
    public GameObject projectile;
}

public enum AttackType
{
    Melee, Range
}
