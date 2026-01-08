using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    float highestY;

    void Start()
    {
        highestY = transform.position.y;
    }

    void Update()
    {
        if (GameManager.GameEnded) return;

        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            transform.position = new Vector3(transform.position.x, highestY, transform.position.z);
        }
    }
}
