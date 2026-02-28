using UnityEngine;

public class WaterLeakInfo : MonoBehaviour
{
    [TextArea(2, 5)]
    public string leakMessage;

    public string correctAnswer;
    public string wrongAnswer;

    private WaterUIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<WaterUIManager>();
    }

    void OnMouseDown()
    {
        if (uiManager != null)
        {
            uiManager.ShowMessage(leakMessage, correctAnswer, wrongAnswer);
        }
    }
}
