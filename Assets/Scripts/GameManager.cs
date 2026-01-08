using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameEnded;

    void Awake()
    {
        Time.timeScale = 1f;   // 🔥 SAHNE AÇILINCA ZAMAN AÇIK OLSUN
        GameEnded = false;
    }

}
