using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverUI; // drag GameOverUI ke slot Inspector

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Matikan player
            gameObject.SetActive(false);

            // Tampilkan UI Game Over
            gameOverUI.SetActive(true);
        }
    }
}
