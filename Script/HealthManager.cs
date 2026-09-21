using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;          
    private int currentHealth;

    public Image[] hearts;             
    public GameObject gameOverPanel;   

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
        gameOverPanel.SetActive(false); 
    }

    public void TakeDamage(int damage = 1)
    {
        // 🚨 Tambahan: kalau lagi minigame, jangan kurangi health
        if (GameFlow.isInMiniGame) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHeartsUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }

    void GameOver()
    {
        // 🚨 Tambahan: jangan munculkan GameOver kalau lagi minigame
        if (GameFlow.isInMiniGame) return;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; 
    }
}
