using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject distanceText; // drag DistanceText UI ke sini lewat Inspector

    public void ShowGameOver()
    {
        // tampilkan panel game over
        gameOverPanel.SetActive(true);

        // sembunyikan DistanceText
        if (distanceText != null)
        {
            distanceText.SetActive(false);
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;

        // aktifkan lagi DistanceText sebelum reload
        if (distanceText != null)
        {
            distanceText.SetActive(true);
        }

        // reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
