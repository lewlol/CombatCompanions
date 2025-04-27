using UnityEngine;

public class BasicAI : MonoBehaviour
{
    Transform target;
    float distanceToTarget;

    Rigidbody rb;
    bool chasing;

    //Stats
    public float moveSpeed;
    public float attackDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget >= attackDistance)
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
        rb.linearVelocity = direction.normalized * moveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
