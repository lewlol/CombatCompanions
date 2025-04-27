using UnityEngine;

[CreateAssetMenu(menuName = "Gun")]
public class Gun : ScriptableObject
{
    [Header("Gun Info")]
    public string gunName;

    [Header("Gun Stats")]
    public float damage;
    public float shootDelay;
    public bool automatic;
    [Space]
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletTime;
}
