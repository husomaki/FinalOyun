using UnityEngine;

public class Gift : MonoBehaviour
{
    public enum GiftType { Jetpack, DoubleJump }
    public GiftType giftType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerPower power = collision.GetComponent<PlayerPower>();

        if (power == null)
        {
            Debug.LogError("PlayerPower scripti PLAYER üzerinde yok!");
            return;
        }

        if (giftType == GiftType.Jetpack)
            power.ActivateJetpack();

        if (giftType == GiftType.DoubleJump)
            power.ActivateDoubleJump();

        Destroy(gameObject);
    }
}
