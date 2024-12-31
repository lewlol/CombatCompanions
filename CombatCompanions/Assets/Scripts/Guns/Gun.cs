using UnityEngine;

[CreateAssetMenu(menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun Information")]
    public string gunName;

    [Header("Gun Stats")]
    public float damage;
    public float attackDelay;
    [Range(0, 0.4f)]public float accuracy;

    public bool automatic;
    [Space]
    //Bullet Stats 
    public GameObject bulletOBJ;
    public float bulletSpeed;
    public float bulletLifetime;
}
