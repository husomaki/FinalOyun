using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    void Update()
    {
        if (Camera.main.transform.position.y - transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}
