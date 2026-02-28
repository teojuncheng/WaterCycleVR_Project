using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private Button button;
    private Color originalColor;

    [SerializeField] private bool isCorrect;   // ✅ True if this is the correct answer
    [SerializeField] private AnswerButton otherButton; // ✅ Reference to the other button

    void Awake()
    {
        button = GetComponent<Button>();
        originalColor = button.image.color; // store default color
    }

    // ✅ Called when user clicks the button
    public void OnClick()
    {
        // highlight this button
        button.image.color = isCorrect ? Color.green : Color.red;

        // highlight the other button in opposite way
        if (otherButton != null)
        {
            otherButton.button.image.color = otherButton.isCorrect ? Color.green : Color.red;
        }
    }

    // ✅ Called by UI Manager when setting up answers
    public void SetAnswer(string text, bool correct, AnswerButton pair)
    {
        isCorrect = correct;
        otherButton = pair;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text; // set label if button has text
    }

    public void ResetColor()
    {
        button.image.color = originalColor;
        if (otherButton != null)
        {
            otherButton.button.image.color = otherButton.originalColor;
        }
    }
}
