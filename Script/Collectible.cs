using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int pointValue = 10; // nilai skor balon

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(pointValue);
            Destroy(gameObject); // balon hilang setelah diambil
        }
    }
}
