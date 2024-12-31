using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; //Player
    Rigidbody2D rb;
    bool isAttacking;
    float c;

    public Enemy enemy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        c = enemy.attackDelay;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if(distanceToPlayer > enemy.attackRange) //Follow Player
        {
            isAttacking = false;
        }
        else //Begin Attacking
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            FollowPlayer();
        }
    }
    private void FollowPlayer()
    {
        Vector2 direction = target.position - transform.position;
        rb.linearVelocity = direction.normalized * enemy.speed;
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
                    break;
                }
            }

            c = enemy.attackDelay;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.attackRange);
    }
}
