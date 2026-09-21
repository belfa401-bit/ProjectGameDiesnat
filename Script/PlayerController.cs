using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private int jumpCount = 0;
    public int maxJump = 2; // maksimal 2 kali lompat

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < maxJump)
            {
                // reset velocity Y biar lompat konsisten
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // reset lompat saat menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
