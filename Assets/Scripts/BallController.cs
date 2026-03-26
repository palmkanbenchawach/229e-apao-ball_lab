using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 15f;

    public float airResistance = 0.05f;
    public float controlFactor = 0.8f;

    public float torqueForce = 15f; // NEW (controls rolling)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(
            Keyboard.current.dKey.isPressed ? 1f : Keyboard.current.aKey.isPressed ? -1f : 0f,
            Keyboard.current.wKey.isPressed ? 1f : Keyboard.current.sKey.isPressed ? -1f : 0f
        );

        Transform cam = Camera.main != null ? Camera.main.transform : null;

        Vector3 moveDir;

        if (cam != null)
        {
            Vector3 forward = cam.forward;
            Vector3 right = cam.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            moveDir = (forward * input.y + right * input.x).normalized;
        }
        else
        {
            moveDir = new Vector3(input.x, 0f, input.y).normalized;
        }

        // LIMIT SPEED
        if (rb.linearVelocity.magnitude < maxSpeed)
        {
            float speedFactor = 1f - (rb.linearVelocity.magnitude / maxSpeed) * controlFactor;
            rb.AddForce(moveDir * acceleration * speedFactor);
        }

        // AIR RESISTANCE
        rb.AddForce(-rb.linearVelocity * airResistance);

        // ?? ADD ROLLING TORQUE
        Vector3 torque = new Vector3(moveDir.z, 0, -moveDir.x);
        rb.AddTorque(torque * torqueForce);
    }
}