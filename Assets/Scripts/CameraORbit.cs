using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;

    public float mouseSensitivity = 0.2f;
    public float minY = -30f;
    public float maxY = 60f;

    public Vector3 offset = new Vector3(0, 3, -6);

    float rotationX = 0f;
    float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // FOLLOW PLAYER
        transform.position = target.position;

        // GET MOUSE INPUT (NEW INPUT SYSTEM)
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        // ROTATE PIVOT
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // MOVE CAMERA
        cameraTransform.position = transform.position + transform.rotation * offset;

        // LOOK AT PLAYER
        cameraTransform.LookAt(transform.position);
    }
}