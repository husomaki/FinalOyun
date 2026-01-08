using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    bool broken = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (broken) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            broken = true;
            Invoke(nameof(Break), 0.1f);
        }
    }

    void Break()
    {
        Destroy(gameObject);
    }
}
