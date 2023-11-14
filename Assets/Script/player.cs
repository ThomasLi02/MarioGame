using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 20.0f;
    private bool isJumping = false;
    public bool facingRight = true;  // variable to track player's direction

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public GameController gameController; // Make sure to assign this in the Inspector



    private float minX, maxX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component

        // Screen boundaries
        float camHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        minX = -camHalfWidth + 0.25f;  // Add half the player's width (assuming 1 unit width)
        maxX = camHalfWidth - 0.25f;  // Subtract half the player's width
    }

    private void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Flipping the sprite based on direction
        if ((moveX > 0 && !facingRight) || (moveX < 0 && facingRight))
        {
            Flip();
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Clamp player's position
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Box"))
        {
            isJumping = false;
        }
        


        if (collision.gameObject.CompareTag("enemy"))
        {
            // Get the position of the collision point
            Vector2 collisionPoint = collision.contacts[0].point;

            float enemyHeight = collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y;

            if (collisionPoint.y < collision.gameObject.transform.position.y + (enemyHeight / 2))
            {
                Destroy(gameObject); // Mario did not land on top of the enemy, so he gets destroyed
                if (gameController != null) // Check if gameController is not null
                {
                    gameController.ShowFailPanel();
                }

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("coin"))
        {
            ScoreKeeper.ScorePoints(1);
            Destroy(collider.gameObject);
        }
    }


    // Flip the player's sprite horizontally
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
