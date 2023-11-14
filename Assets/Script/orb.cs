using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour

{
    public float bounceForce = 3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x,  bounceForce);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);

        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
