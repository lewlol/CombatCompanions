using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;

    [Header("Enemy Stats")]
    public float health;
    [Space]
    public float moveSpeed;
    public float attackDistance;
}
