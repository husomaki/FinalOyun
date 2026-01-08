using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public AudioClip jumpClip;

    Rigidbody2D rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.ignoreListenerPause = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            if (jumpClip != null)
                audioSource.PlayOneShot(jumpClip);
        }
    }
}
