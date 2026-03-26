using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform target; // where to teleport
    public float cooldown = 0.5f;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Teleport(other));
        }
    }

    System.Collections.IEnumerator Teleport(Collider player)
    {
        canTeleport = false;

        Rigidbody rb = player.GetComponent<Rigidbody>();

        // stop movement before teleport
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        // teleport
        player.transform.position = target.position;

        yield return new WaitForSeconds(cooldown);

        canTeleport = true;
    }
}