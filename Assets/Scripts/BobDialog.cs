using UnityEngine;
using TMPro;

public class BobDialog : MonoBehaviour
{
    public TextMeshPro dialogText;   // Drag the 3D TextMeshPro object here in Inspector
    public string[] messages;        // Add your dialog lines in Inspector
    private int currentMessageIndex = 0;

    void Start()
    {
        // Hide Bob’s dialog at the start
        if (dialogText != null)
        {
            dialogText.gameObject.SetActive(false);
        }
    }

    public void ShowNextMessage()
    {
        if (dialogText != null && messages.Length > 0)
        {
            // Enable dialog if hidden
            dialogText.gameObject.SetActive(true);

            // Show the current message
            dialogText.text = messages[currentMessageIndex];

            // Move to the next one (loop if needed)
            currentMessageIndex = (currentMessageIndex + 1) % messages.Length;
        }
    }
}
