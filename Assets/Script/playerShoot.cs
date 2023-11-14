using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject fireOrbPrefab;
    public Transform fireOrbSpawnPoint;
    public float fireOrbSpeed = 10f;
    
    private PlayerController playerController; // Reference to the PlayerController script to check the direction

    void Start()
    {
        playerController = GetComponent<PlayerController>(); // Get the PlayerController component from the same GameObject
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Replace 'F' with your desired shooting key.
        {
            ShootFireOrb();
        }
    }

    void ShootFireOrb()
    {
        Vector2 shootDirection = Vector2.right; // Default shoot direction is to the right
        Vector2 spawnPosition = transform.position + transform.right;
        // If player is not facing right, shoot to the left
        if (!playerController.facingRight)
        {
            shootDirection = Vector2.left;
            spawnPosition = transform.position - transform.right;
        }

        GameObject fireOrb = Instantiate(fireOrbPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireOrb.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * fireOrbSpeed;
    }
}
