using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator compAnim;
    SpriteRenderer sr;

    float c;
    bool isTarget;

    Transform player;
    Transform target;

    public Companion companion;
    public float followDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        compAnim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (target != null) //There is a target to kill
        {
            isTarget = true;
        }
        else //There is no target
        {
            isTarget = false;
        }

        if (isTarget) //Attack is there is a target
        {
            FollowTarget(target);
            AttackTarget();
        }

        if (!isTarget) //Search for enemy is there is a target
        {
            SearchForEnemy();
        }

        //Swapping Animations
        if(rb.linearVelocity == Vector2.zero)
        {
            compAnim.SetBool("isWalking", false);
        }
        else
        {
            compAnim.SetBool("isWalking", true);
        }
    }

    private void FixedUpdate()
    {
        if (!isTarget)
        {
            FollowTarget(player);
        }
    }
    private void AttackTarget()
    {
        float countDown = c -= Time.deltaTime;
        if (countDown <= 0)
        {
            GameObject newProj = Instantiate(companion.projectile, transform.position, Quaternion.identity);
            Vector2 bulletDir = target.position - transform.position;
            newProj.GetComponent<Rigidbody2D>().linearVelocity = bulletDir * companion.projectileSpeed;
            newProj.GetComponent<Projectile>().damage = companion.damage;

            c = companion.attackDelay;

            GameEvent.gameEvent.SpawnSound(transform.position, SoundLib.sounds.shootSound);
        }
    }

    private void SearchForEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, companion.attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                target = collider.transform;
            }
        }
    }

    private void FollowTarget(Transform interest)
    {
        float distanceToPlayer = Vector2.Distance(transform.position, interest.position);
        if (distanceToPlayer > followDistance)
        {
            Vector2 dir = interest.position - transform.position;
            rb.linearVelocity = dir.normalized * companion.speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        //Flip Sprite depending on position of target from companion
        float xDir = interest.position.x - transform.position.x;
        if(xDir <= 0)
            sr.flipX = true;
        else 
            sr.flipX = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, companion.attackRange);
    }
}
