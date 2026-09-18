using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("RunnerScene"); // ganti sesuai nama scene game
    }

    public void QuitGame()
    {
        Application.Quit(); // hanya jalan di build, bukan di editor
    }
}
