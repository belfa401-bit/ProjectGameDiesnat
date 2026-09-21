using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthManager healthManager; // ini bikin slot muncul di Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (healthManager != null)
            {
                healthManager.TakeDamage(1);
            }
            Destroy(collision.gameObject);
        }
    }
}
