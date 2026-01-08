using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject breakablePlatformPrefab;
    public GameObject giftPrefab;

    public Transform player;

    [Header("Row Settings")]
    public int minPlatformsPerRow = 1;
    public int maxPlatformsPerRow = 3;

    public float distance = 2.2f;
    float spawnY;

    bool isLevel2;

    void Start()
    {
        isLevel2 = SceneManager.GetActiveScene().name == "Level2";
        spawnY = player.position.y;

        // Başlangıçta birkaç platform
        for (int i = 0; i < 8; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Player spawn noktasına yaklaştıkça yeni platform üret
        if (player.position.y + 8f > spawnY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        int platformCount = Random.Range(minPlatformsPerRow, maxPlatformsPerRow + 1);

        float lastX = 100f;

        for (int i = 0; i < platformCount; i++)
        {
            float x;

            // Platformlar üst üste binmesin
            do
            {
                x = Random.Range(-5f, 5f);
            }
            while (Mathf.Abs(x - lastX) < 1.2f);

            lastX = x;

            Vector3 pos = new Vector3(x, spawnY, 0f);

            GameObject platform;

            if (isLevel2 && Random.value < 0.3f)
                platform = Instantiate(breakablePlatformPrefab, pos, Quaternion.identity);
            else
                platform = Instantiate(platformPrefab, pos, Quaternion.identity);

            // Gift ihtimali (satır başına değil, platform başına)
            if (giftPrefab != null && Random.value < 0.08f)
            {
                Instantiate(giftPrefab, pos + Vector3.up * 0.7f, Quaternion.identity);
            }
        }

        spawnY += distance;
    }

}
