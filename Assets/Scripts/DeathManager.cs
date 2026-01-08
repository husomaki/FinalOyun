using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void Die()
    {
        if (GameManager.GameEnded) return;

        GameManager.GameEnded = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        GameManager.GameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.GameEnded = false;
        SceneManager.LoadScene("MainMenu");
    }

}
