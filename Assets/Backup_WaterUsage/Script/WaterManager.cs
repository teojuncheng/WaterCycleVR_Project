using UnityEngine;

public class WaterManager : MonoBehaviour
{
    [Header("Water Objects (parents that contain the ParticleSystem as a child)")]
    public GameObject[] waterObjects;  // Assign all your water prefabs here

    private ParticleSystem[] waterParticles;
    private AudioSource[] waterAudios;

    [Header("Optional: One global water sound (e.g., near camera)")]
    public AudioSource globalWaterAudio;

    [Header("Water Usage Settings")]
    public float litersPerSecond = 10f;   // ✅ one global rate you can edit anytime
    private bool isWaterOn = false;
    private float totalLitersUsed = 0f;

    void Start()
    {
        waterParticles = new ParticleSystem[waterObjects.Length];
        waterAudios = new AudioSource[waterObjects.Length];

        for (int i = 0; i < waterObjects.Length; i++)
        {
            var go = waterObjects[i];
            if (go == null) continue;

            waterParticles[i] = go.GetComponentInChildren<ParticleSystem>(true);
            waterAudios[i] = go.GetComponentInChildren<AudioSource>(true);

            if (waterParticles[i] == null)
                Debug.LogWarning($"[WaterManager] No ParticleSystem found under {go.name}");
        }

        if (globalWaterAudio != null && globalWaterAudio.isPlaying)
            globalWaterAudio.Stop();
    }

    void Update()
    {
        // While water is ON, keep counting usage
        if (isWaterOn)
        {
            totalLitersUsed += litersPerSecond * Time.deltaTime;
        }
    }

    public void TurnOnWater()
    {
        isWaterOn = true;

        for (int i = 0; i < waterObjects.Length; i++)
        {
            var go = waterObjects[i];
            if (go == null) continue;

            if (!go.activeSelf) go.SetActive(true);

            var ps = waterParticles[i];
            if (ps != null && !ps.isPlaying)
                ps.Play(true);

            var a = waterAudios[i];
            if (a != null && !a.isPlaying)
                a.Play();
        }

        if (globalWaterAudio != null && !globalWaterAudio.isPlaying)
            globalWaterAudio.Play();

        Debug.Log("WATER ON");
    }

    public void TurnOffWater()
    {
        isWaterOn = false;

        for (int i = 0; i < waterObjects.Length; i++)
        {
            var go = waterObjects[i];
            if (go == null) continue;

            var ps = waterParticles[i];
            if (ps != null)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            var a = waterAudios[i];
            if (a != null && a.isPlaying)
                a.Stop();

            if (go.activeSelf) go.SetActive(false);
        }

        if (globalWaterAudio != null && globalWaterAudio.isPlaying)
            globalWaterAudio.Stop();

        Debug.Log($"WATER OFF - Total Used: {totalLitersUsed:F2} liters");
    }

    public float GetTotalUsage()
    {
        return totalLitersUsed;
    }

    public void ResetUsage()
    {
        totalLitersUsed = 0f;
    }
}
