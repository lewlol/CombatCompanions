using UnityEngine;

[CreateAssetMenu(menuName = "Companion")]
public class Companion : ScriptableObject
{
    [Header("Companion Info")]
    public string companionName;
    public string companionDescription;
    public GameObject companionPrefab;

    [Space] //Merchant Stuff
    public Sprite companionSprite;
    public int companionCost;

    [Header("Companion Generic Stats")]
    public float speed;
    public float stopRadius;

    [Header("Companion Combat Stats")]
    public float damage;
    public float attackRange;
    public float attackDelay;
    [Space] //Ranged Stats
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileLifetime;
}
