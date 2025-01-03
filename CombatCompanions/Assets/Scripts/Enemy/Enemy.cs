using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;

    [Header("Enemy Generic Stats")]
    public float speed;
    public float maxHealth;
    [Space]
    [Range(0, 1)]public float dropChance;
    public GameObject[] drops;

    [Header("Enemy Combat Stats")]
    public float damage;
    public float attackRange;
    public float attackDelay;
}
