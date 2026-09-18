using UnityEngine;
using TMPro;   // pakai TMP

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
        scoreText.text = "Score: " + score;
    }

    // Bisa dipanggil dari collectible atau mini-game
    public int GetScore()
    {
        return score;
    }
}
