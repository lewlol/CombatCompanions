using System.Net.Sockets;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    Transform player;
    Animator animator;
    SpriteRenderer sr;

    bool attackingPlayer;
    float c;

    public Enemy enemy;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer > enemy.attackRange) //Run to Player
        {
            attackingPlayer = false;
            animator.SetBool("isAttacking", false);
        }
        else //Attack Player
        {
            attackingPlayer = true;
            animator.SetBool("isAttacking", true);
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (!attackingPlayer)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        Vector2 dir = player.position - transform.position;
        rb.linearVelocity = dir.normalized * enemy.moveSpeed;

        if(dir.x <= 0)
            sr.flipX = true;
        else
            sr.flipX = false;

    }

    private void AttackPlayer()
    {
        rb.linearVelocity = Vector2.zero;
        float countDown = c -= Time.deltaTime;
        if(countDown <= 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemy.attackRange + 0.5f);
            foreach(Collider2D collider in colliders)
            {
                if(collider.gameObject.tag == "Player")
                {
                    collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemy.damage);
                    GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.attackSound);
                    c = enemy.attackDelay;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.attackRange);
    }
}
