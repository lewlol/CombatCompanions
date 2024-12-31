using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;

    [Header("Enemy Generic Stats")]
    public float speed;
    public float maxHealth;

    [Header("Enemy Combat Stats")]
    public float damage;
    public float attackRange;
    public float attackDelay;
}
