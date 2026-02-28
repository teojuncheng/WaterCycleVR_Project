using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject introPanel;   // The message "This is a water simulation..."
    public GameObject waterUI;      // The parent object that holds both On & Off buttons

    [Header("Timing")]
    public float introDuration = 5f;   // seconds to show the intro message

    private float timer;

    void Start()
    {
        // Show intro at start, hide water UI
        introPanel.SetActive(true);
        waterUI.SetActive(false);

        timer = introDuration;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                // Hide intro, show water UI group
                introPanel.SetActive(false);
                waterUI.SetActive(true);
            }
        }
    }
}
