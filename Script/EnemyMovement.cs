using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Gerak horizontal ke kiri
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }

    void Update()
    {
        // Hapus kalau keluar layar
        if (transform.position.x < -30f)
        {
            Destroy(gameObject);
        }
    }
}
