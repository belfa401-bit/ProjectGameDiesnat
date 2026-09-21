using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject distanceText; 

    public void ShowGameOver()
    {
        // 🚨 Tambahan: jangan munculkan GameOver kalau lagi minigame
        if (GameFlow.isInMiniGame) return;

        gameOverPanel.SetActive(true);

        if (distanceText != null)
        {
            distanceText.SetActive(false);
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;

        if (distanceText != null)
        {
            distanceText.SetActive(true);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
