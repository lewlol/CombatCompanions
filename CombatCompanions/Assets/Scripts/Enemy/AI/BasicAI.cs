using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public Enemy enemy;

    Transform target;
    float distanceToTarget;

    Rigidbody rb;
    bool chasing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget >= enemy.attackDistance)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }

        if (!chasing)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (chasing)
        {
            ChaseTarget();
        }
    }

    private void ChaseTarget()
    {
        Vector3 direction = target.position - transform.position;
        rb.linearVelocity = direction.normalized * enemy.moveSpeed;
    }

    private void AttackTarget()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemy.attackDistance);
    }
}
