using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public static bool isInMiniGame = false; // flag global

    public GameObject gamePanel;        
    public GameObject instructionPanel; 
    public FlipCardManager flipCardManager; 

    public void NextFromInstruction()
    {
        instructionPanel.SetActive(false);
        gamePanel.SetActive(true);

        if (flipCardManager != null)
        {
            flipCardManager.StartTimer();
        }

        Time.timeScale = 1f;
        isInMiniGame = true; // masuk minigame
    }

    public void NextFromWin()
    {
        ScoreManager.instance.AddScore(100);
        gamePanel.SetActive(false);
        instructionPanel.SetActive(false);
        Time.timeScale = 1f;
        isInMiniGame = false; // keluar minigame
    }

    public void NextFromLose()
    {
        ScoreManager.instance.AddScore(-100);
        gamePanel.SetActive(false);
        instructionPanel.SetActive(false);
        Time.timeScale = 1f;
        isInMiniGame = false; // keluar minigame
    }
}
