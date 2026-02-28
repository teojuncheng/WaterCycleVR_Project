using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private Button button;
    private Color originalColor;

    [SerializeField] private bool isCorrect;
    [SerializeField] private AnswerButton otherButton;

    void Awake()
    {
        button = GetComponent<Button>();
        originalColor = button.image.color; // store starting color
    }

    // ✅ When user clicks this button
    public void OnClick()
    {
        // highlight this one
        button.image.color = isCorrect ? Color.green : Color.red;

        // highlight the other one too
        if (otherButton != null)
        {
            otherButton.button.image.color = otherButton.isCorrect ? Color.green : Color.red;
        }
    }

    // ✅ Setup answer text & pair
    public void SetAnswer(string text, bool correct, AnswerButton pair)
    {
        isCorrect = correct;
        otherButton = pair;
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    // ✅ Reset only THIS button’s color
    public void ResetColor()
    {
        if (button != null)
        {
            button.image.color = originalColor;
        }
    }
}
