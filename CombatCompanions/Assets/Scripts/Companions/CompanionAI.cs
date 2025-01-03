using System.Collections;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    bool following;
    bool attacking;

    bool canAttack;

    Transform target;
    Transform player;

    //Stats
    public Companion companion;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        if(distance > companion.stopRadius) //Follow Target
        {
            following = true;
        }
        else //Start Following
        {
            following = false;
            rb.linearVelocity = Vector2.zero;
        }

        //Sprite Flipping
        if(rb.linearVelocityX > 0)
        {
            sr.flipX = false;
        }else if(rb.linearVelocityX < 0)
        {
            sr.flipX = true;
        }

        //Animations
        if(rb.linearVelocity != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
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
        rb.linearVelocity = direction.normalized * companion.speed;
    }

    private void AttackEnemy()
    {
        Vector2 direction = target.position - transform.position;

        GameObject newProjectile = Instantiate(companion.projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * companion.projectileSpeed;
        newProjectile.GetComponent<Bullet>().damage = companion.damage;

        Destroy(newProjectile, companion.projectileLifetime);
        StartCoroutine(CanAttackEnum());
    }

    private void SearchForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, companion.attackRange);
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
        Gizmos.DrawWireSphere(transform.position, companion.stopRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, companion.attackRange);
    }

    IEnumerator CanAttackEnum()
    {
        canAttack = false;
        yield return new WaitForSeconds(companion.attackDelay);
        canAttack = true;
    }
}
