using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    private bool movingRight = true;
    private float leftBoundary, rightBoundary;

    void Start()
    {
        // Calculate screen boundaries
        float camHalfWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        leftBoundary = -camHalfWidth + 0.25f;
        rightBoundary = camHalfWidth - 0.25f;

    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // Check if enemy has reached the right boundary
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // Check if enemy has reached the left boundary
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            movingRight = !movingRight;
            if (movingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

        // Check for player collision
        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Check if player is above the enemy
            if (collision.contacts[0].normal.y < -0.5)
            {
                ScoreKeeper.ScorePoints(1);
                Destroy(gameObject); // Destroy the enemy
            }
        }
        if (collision.gameObject.CompareTag("fireOrb"))
        {
            // Check if player is above the enemy
            ScoreKeeper.ScorePoints(1);
            Destroy(gameObject);
        }
    }
}
