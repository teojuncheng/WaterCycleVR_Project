using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public Camera mainCam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.Log("You clicked: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("Nothing hit");
            }
        }
    }
}
