using UnityEngine;
using UnityEngine.UI;

public class TemperatureController : MonoBehaviour
{
    [Header("Temperature Settings")]
    public Slider temperatureSlider;
    [Range(0f, 100f)] public float temperatureValue;
    public Color coldColor = Color.blue;
    public Color hotColor = new Color(1f, 0.4f, 0f); // Orange-red

    [Header("Visual Environment")]
    public Renderer environmentSphereRenderer;

    private Material environmentMaterialInstance;

    void Start()
    {
        if (environmentSphereRenderer != null)
        {
            // Create unique instance of material
            environmentMaterialInstance = Instantiate(environmentSphereRenderer.material);
            environmentSphereRenderer.material = environmentMaterialInstance;
        }
        else
        {
            Debug.LogWarning("Environment Sphere Renderer is not assigned.");
        }
    }

    void Update()
    {
        if (temperatureSlider != null)
        {
            temperatureValue = temperatureSlider.value;
        }

        // Update all water molecules
        WaterMoleculeBehavior[] molecules = FindObjectsOfType<WaterMoleculeBehavior>();
        foreach (var molecule in molecules)
        {
            molecule.SetTemperature(temperatureValue);
        }

        // Update environment sphere color
        if (environmentMaterialInstance != null)
        {
            float t = Mathf.InverseLerp(0f, 100f, temperatureValue);
            Color targetColor = Color.Lerp(coldColor, hotColor, t);
            environmentMaterialInstance.color = targetColor;
        }
    }
}
