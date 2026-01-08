using UnityEngine;

public class JetpackFire : MonoBehaviour
{
    void Update()
    {
        float scale = 0.8f + Mathf.PingPong(Time.time * 0.5f, 0.3f);
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
