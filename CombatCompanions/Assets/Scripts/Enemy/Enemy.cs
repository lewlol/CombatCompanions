using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;
    public GameObject enemyPrefab;
    public PossibleDrop[] drops;

    [Header("General Stats")]
    public float maxHealth;
    public float moveSpeed;
    public float points;

    [Header("Attack Stats")]
    public float damage;
    public float attackRange;
    public float attackDelay;
}


[System.Serializable]
public class PossibleDrop 
{
    public GameObject drop;
    public float dropChance;
}

