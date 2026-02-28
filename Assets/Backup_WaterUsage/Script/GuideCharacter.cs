using UnityEngine;

public class GuideCharacter : MonoBehaviour
{
    public void ShowCharacter()
    {
        gameObject.SetActive(true);
    }

    public void HideCharacter()
    {
        gameObject.SetActive(false);
    }
}
