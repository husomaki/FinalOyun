using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public GameObject levelCompletePanel;

    public void Show()
    {
        if (GameManager.GameEnded) return;

        GameManager.GameEnded = true;
        Time.timeScale = 0f;

        levelCompletePanel.SetActive(true);

        CanvasGroup cg = levelCompletePanel.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = 1;
            cg.interactable = true;
            cg.blocksRaycasts = true;
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        GameManager.GameEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.GameEnded = false;
        SceneManager.LoadScene("MainMenu");
    }
}
