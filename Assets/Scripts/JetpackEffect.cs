using UnityEngine;

public class JetpackEffect : MonoBehaviour
{
    public float rotateSpeed = 360f;
    public Transform fire;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        if (fire != null)
        {
            float scale = 0.8f + Mathf.PingPong(Time.time * 0.5f, 0.3f);
            fire.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
