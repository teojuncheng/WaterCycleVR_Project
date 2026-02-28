using UnityEngine;

public class MasterWaterController : MonoBehaviour
{
    private WaterController[] allWater;

    void Start()
    {
        allWater = FindObjectsOfType<WaterController>();
    }

    public void TurnOnAll()
    {
        Debug.Log("TurnOnAll button pressed!");
        foreach (var wc in allWater)
        {
            wc.TurnOn();
        }
    }

    public void TurnOffAll()
    {
        Debug.Log("TurnOffAll button pressed!");
        foreach (var wc in allWater)
        {
            wc.TurnOff();
        }
    }
}
