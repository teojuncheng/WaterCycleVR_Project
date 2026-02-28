using UnityEngine;

public class ResetCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // unlocks the mouse
        Cursor.visible = true; // makes cursor visible
    }
}
