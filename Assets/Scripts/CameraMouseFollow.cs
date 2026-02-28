using UnityEngine;

public class FullMouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply both vertical and horizontal rotation to the camera itself
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
