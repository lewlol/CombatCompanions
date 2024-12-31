using System.Collections;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    Rigidbody2D rb;
    bool following;
    bool attacking;

    bool canAttack;

    public Transform target;
    public Transform player;

    //Stats
    public float stopRadius;
    public float attackRange;
    public float speed;
    public GameObject projectile;
    public float projectileSpeed;
    public float attackDelay;
    public float projectileLifetime;
    public float damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        canAttack = true;
    }

    private void Update()
    {
        Transform currentInterest = player;
        if (target != null)//Follow the target and try to Attack
        {
            currentInterest = target;

            if(canAttack)
                AttackEnemy();
        }
        else //There is no target so we can search while following
        {
            SearchForEnemies();
        }

        float distance = Vector2.Distance(transform.position, currentInterest.position);
        if(distance > stopRadius) //Follow Target
        {
            following = true;
        }
        else //Start Following
        {
            following = false;
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        //Decide whether to follow the player or a target
        if (!following)
            return;

        if (target != null)//Follow the target and try to Attack
        {
            FollowTarget(target);
        }
        else //Follow Player and Search for a Target 
        {
            FollowTarget(player);
        }
    }

    private void FollowTarget(Transform interest)
    {
        Vector2 direction = interest.position - transform.position;
        rb.linearVelocity = direction * speed;
    }

    private void AttackEnemy()
    {
        Vector2 direction = target.position - transform.position;

        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * projectileSpeed;
        newProjectile.GetComponent<Bullet>().damage = damage;

        Destroy(newProjectile, projectileLifetime);
        StartCoroutine(CanAttackEnum());
    }

    private void SearchForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                target = collider.gameObject.transform;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    IEnumerator CanAttackEnum()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
