using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 3f; // kecepatan gerak ke kiri

    void Update()
    {
        // Geser object ke kiri setiap frame
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Kalau sudah keluar layar (misalnya x < -10), hapus object
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
