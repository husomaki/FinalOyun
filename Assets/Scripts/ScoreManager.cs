using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public int targetScore = 100;
    public LevelCompleteManager levelCompleteManager;

    float startY;
    int score;

    void Start()
    {
        startY = player.position.y;
        score = 0;
        UpdateText();
    }

    void Update()
    {
        if (GameManager.GameEnded) return;

        float height = player.position.y - startY;
        int newScore = Mathf.FloorToInt(height);

        if (newScore > score)
        {
            score = newScore;
            UpdateText();

            if (score >= targetScore)
            {
                levelCompleteManager.Show();
            }
        }
    }

    void UpdateText()
    {
        scoreText.text = score + "/" + targetScore;
    }
}
