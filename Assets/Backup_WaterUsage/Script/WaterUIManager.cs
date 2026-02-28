using UnityEngine;
using TMPro;

public class WaterUIManager : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public GameObject waterCharacter;
    public AnswerButton[] answerButtons; // drag ALL answer buttons here in Inspector

    // Show message + assign answers
    public void ShowMessage(string msg, string correctAns, string wrongAns)
    {
        messagePanel.SetActive(true);
        messageText.text = msg;

        if (waterCharacter != null)
            waterCharacter.SetActive(true);

        // setup answer buttons (assuming you only have 2)
        if (answerButtons.Length >= 2)
        {
            answerButtons[0].SetAnswer(correctAns, true, answerButtons[1]);
            answerButtons[1].SetAnswer(wrongAns, false, answerButtons[0]);
        }
    }


    public void HideMessage()
    {
        messagePanel.SetActive(false);

        if (waterCharacter != null)
            waterCharacter.SetActive(false);

        // Reset all buttons when panel closes
        foreach (var btn in answerButtons)
        {
            btn.ResetColor();
        }
    }
}
