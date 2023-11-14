using UnityEngine;

public class Box : MonoBehaviour
{
    public bool hasGold = true;
    private SpriteRenderer spriteRenderer;
    public Color brownColor = new Color(0.6f, 0.4f, 0.2f);
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 collisionPoint = collision.contacts[0].point;

            // Check if the collision point is below the box's center
            if (collision.contacts[0].normal.y > 0.5 && hasGold)
            {
                ScoreKeeper.ScorePoints(1); // Increase the score
                hasGold = false; // The box no longer contains gold
                spriteRenderer.color = brownColor;
            }

        }
    }
}
