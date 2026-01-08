using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour
{
    PlayerMove movement;

    [Header("Jetpack")]
    public GameObject jetpackPrefab;
    GameObject activeJetpack;

    [Header("Double Jump")]
    bool canDoubleJump = false;
    bool usedDoubleJump = false;

    void Start()
    {
        movement = GetComponent<PlayerMove>();
    }

    // 🚀 JETPACK
    public void ActivateJetpack()
    {
        if (activeJetpack != null) return;

        activeJetpack = Instantiate(jetpackPrefab, transform);
        activeJetpack.transform.localPosition = new Vector3(0, -0.4f, 0);

        movement.jetpackActive = true;
        StartCoroutine(JetpackDuration());
    }

    IEnumerator JetpackDuration()
    {
        yield return new WaitForSeconds(5f);

        movement.jetpackActive = false;
        Destroy(activeJetpack);
    }

    // ⬆️ DOUBLE JUMP
    public void ActivateDoubleJump()
    {
        canDoubleJump = true;
    }

    public bool TryDoubleJump()
    {
        if (canDoubleJump && !usedDoubleJump)
        {
            usedDoubleJump = true;
            return true;
        }
        return false;
    }

    public void ResetJump()
    {
        usedDoubleJump = false;
    }
}
