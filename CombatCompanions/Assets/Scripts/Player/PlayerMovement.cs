using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool dead;
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed;

    void Start()
    {
        PlayerEvents.playerEvent.onPlayerDied += PlayerDied;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
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