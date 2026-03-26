using UnityEngine;

[ExecuteAlways] // Works in Editor and Play Mode
[RequireComponent(typeof(Renderer))]
public class RainbowEmissionNoShader : MonoBehaviour
{
    public float emissionIntensity = 4.91692f; // HDR intensity
    public float rainbowSpeed = 1f;            // Speed of rainbow cycle

    private Material mat;

    void Awake()
    {
        // Use the Renderer’s material (creates a unique instance)
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION"); // Ensure emission is on
    }

    void Update()
    {
        if (mat == null) return;

        // Animated rainbow color using sine waves
        float t = Time.time * rainbowSpeed;
        float r = Mathf.Sin(t) * 0.5f + 0.5f;
        float g = Mathf.Sin(t + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(t + 4f) * 0.5f + 0.5f;

        Color rainbowColor = new Color(r, g, b) * emissionIntensity;

        // Apply to material
        mat.SetColor("_EmissionColor", rainbowColor);
    }
}