using UnityEngine;
using TMPro;   // ✅ make sure you have TextMeshPro imported

public class WaterUI : MonoBehaviour
{
    [Header("References")]
    public WaterManager waterManager;       // Drag your WaterManager here
    public TextMeshProUGUI usageText;       // Drag your UI text here

    void Update()
    {
        if (waterManager != null && usageText != null)
        {
            float liters = waterManager.GetTotalUsage();
            usageText.text = $"Water Used: {liters:F2} L";
        }
    }
}
