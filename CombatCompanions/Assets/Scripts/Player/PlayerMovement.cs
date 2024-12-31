using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool dead;
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed;

    Animator anim;
    SpriteRenderer sr;
    void Start()
    {
        PlayerEvents.playerEvent.onPlayerDied += PlayerDied;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        //Switching Movement Animations
        Vector2 movement = new Vector2(horizontal, vertical);
        if(movement != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(horizontal < 0)
        {
            sr.flipX = true;
        }else if(horizontal > 0)
        {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        if (dead)
            return;

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void PlayerDied()
    {
        dead = true;
    }
}
