using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    private float startX;             // posisi awal player
    private float nextThreshold = 100f; // tiap 100 meter

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x; // simpan posisi awal
    }

    void Update()
    {
        // Auto-run
        rb.linearVelocity = new Vector2(runSpeed, rb.linearVelocity.y);

        // Hitung jarak berdasarkan posisi
        float distance = transform.position.x - startX;

        // Cek threshold
        if (distance >= nextThreshold)
        {
            runSpeed += 1f;          // naik speed 1
            nextThreshold += 100f;   // target berikutnya
            Debug.Log("Speed naik! Sekarang: " + runSpeed);
        }

        // Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
