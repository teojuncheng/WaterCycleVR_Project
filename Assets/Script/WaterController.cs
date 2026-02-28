using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject waterVisual;
    private ParticleSystem ps;

    void Awake()
    {
        if (waterVisual != null)
            ps = waterVisual.GetComponent<ParticleSystem>();
    }

    public void TurnOn()
    {
        if (waterVisual != null)
        {
            waterVisual.SetActive(true);

            if (ps != null)
                ps.Play(true); // force restart particles
        }
        Debug.Log(name + " water turned ON");
    }

    public void TurnOff()
    {
        if (waterVisual != null)
        {
            if (ps != null)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            waterVisual.SetActive(false);
        }
        Debug.Log(name + " water turned OFF");
    }
}
