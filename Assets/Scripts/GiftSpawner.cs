using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    public GameObject giftPrefab;

    float nextSpawnY = 10f;

    void Update()
    {
        if (Camera.main.transform.position.y > nextSpawnY - 8f)
        {
            SpawnGift();
        }
    }

    void SpawnGift()
    {
        float x = Random.Range(-2f, 2f);
        Vector3 pos = new Vector3(x, nextSpawnY, 0f);

        Instantiate(giftPrefab, pos, Quaternion.identity);

        // DAHA SEYREK
        nextSpawnY += Random.Range(12f, 20f);
    }
}
