using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishByHeight : MonoBehaviour
{
    public float finishHeight = 40f;

    void Update()
    {
        if (transform.position.y >= finishHeight)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
