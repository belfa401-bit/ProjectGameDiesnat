using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    // Tambahan: biar UI selalu sinkron
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Kalau mau reset manual (misalnya saat game over)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
}
