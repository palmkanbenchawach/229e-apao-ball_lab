using UnityEngine;
using System.Collections;

public class TeleportDamage : MonoBehaviour
{
    public Transform target;
    public float cooldown = 0.5f;
    public int damage = 1;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(TeleportAndDamage(other));
        }
    }

    IEnumerator TeleportAndDamage(Collider player)
    {
        canTeleport = false;

        // ?? ทำดาเมจก่อน
        PlayerHealth hp = player.GetComponent<PlayerHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }

        Rigidbody rb = player.GetComponent<Rigidbody>();

        // ?? หยุดการเคลื่อนที่ก่อนวาป
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        // ?? วาป
        player.transform.position = target.position;

        yield return new WaitForSeconds(cooldown);

        canTeleport = true;
    }
}