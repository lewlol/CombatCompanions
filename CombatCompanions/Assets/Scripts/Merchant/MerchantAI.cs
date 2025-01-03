using System.Collections;
using UnityEngine;

public class MerchantAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    //Movement
    public float speed;
    public float xBoundary;
    public float yBoundary;
    Vector3 location;
    bool idle;

    //Shop
    bool canOpenShop;
    bool shopOpen;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();

        StartCoroutine(IdleTimer());
    }

    private void Update()
    {
        if (!idle && !shopOpen)
        {
            MoveToLocation();
        }

        if(shopOpen)
            rb.linearVelocity = Vector2.zero;

        if (canOpenShop)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!shopOpen)
                    OpenShop();
                else
                    CloseShop();
            }
        }

        if (rb.linearVelocity == Vector2.zero)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    public void FindLocation()
    {
        location = new Vector3(Random.Range(-xBoundary, xBoundary), Random.Range(-yBoundary, yBoundary), 0);
    }

    public void MoveToLocation()
    {
        //Movement
        Vector2 direction = location - transform.position;
        rb.linearVelocity = direction.normalized * speed;

        //Flipping Sprite
        if(direction.x > location.x)
        {
            sr.flipX = false;
        }else if(direction.x < location.x)
        {
            sr.flipX = true;
        }

        //Checking Distance to Location
        float distance = Vector3.Distance(location, transform.position);
        if (distance <= 1)
        {
            StartCoroutine(IdleTimer());
        }
    }

    IEnumerator IdleTimer()
    {
        idle = true;
        rb.linearVelocity = Vector2.zero;

        float idleTime = Random.Range(5, 20);
        yield return new WaitForSeconds(idleTime);

        FindLocation();
        idle = false;
    }

    //Shop
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canOpenShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canOpenShop = false;
            CloseShop();
        }
    }

    public void OpenShop()
    {
        shopOpen = true;
        GameEvents.gameEvent.OpenMerchantUI();
    }

    public void CloseShop()
    {
        shopOpen = false;
        GameEvents.gameEvent.CloseMerchantUI();
    }
}
