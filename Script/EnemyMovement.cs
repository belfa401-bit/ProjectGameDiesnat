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
        // Ambil posisi batas kiri kamera
        float leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        // Hapus kalau sudah keluar layar (lebih kecil dari batas kiri kamera)
        if (transform.position.x < leftBound - 2f) // -2f biar aman sedikit di luar layar
        {
            Destroy(gameObject);
        }
    }
}
