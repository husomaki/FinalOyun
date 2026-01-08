using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public DeathManager deathManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            deathManager.Die();
        }
    }
}
