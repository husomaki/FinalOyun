using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool jetpackActive = false;

    Rigidbody2D rb;
    PlayerPower power;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        power = GetComponent<PlayerPower>();
    }

    void Update()
    {
        if (GameManager.GameEnded) return;

        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (jetpackActive)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (power != null && power.TryDoubleJump())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            power?.ResetJump();

            if (rb.velocity.y <= 0 && !jetpackActive)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}
