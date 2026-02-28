using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TrashClick : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject clickMarkerPrefab;

    // UI elements
    public GameObject winMessageUI;
    public Button restartButton;
    public TMP_Text instructionText;

    // Water references
    public GameObject pollutedWater;
    public GameObject cleanWater;

    // NEW: Pollution phase target
    public Transform pollutionTarget;
    public float showDistance = 0.5f; // how close camera must be to show instruction

    // --- NEW: Bob dialog ---
    public TMP_Text bobDialogText;   // put Bob's dialog text here in Inspector
    public string[] bobMessages;     // assign different messages in Inspector
    private int currentMessageIndex = 0;

    private int totalTrash;
    private int trashLeft;
    private bool instructionShown = false;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // Count all trash
        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");
        totalTrash = trashObjects.Length;
        trashLeft = totalTrash;

        // Hide UI at start
        if (winMessageUI != null) winMessageUI.SetActive(false);
        if (restartButton != null) restartButton.gameObject.SetActive(false);

        // Hide instructions at start
        if (instructionText != null) instructionText.text = "";

        // Ensure polluted water is visible, clean water hidden
        if (pollutedWater != null) pollutedWater.SetActive(true);
        if (cleanWater != null) cleanWater.SetActive(false);

        // Restart button listener
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartScene);

        // Hide Bob dialog at start
        if (bobDialogText != null)
            bobDialogText.gameObject.SetActive(false);
    }

    void Update()
    {
        // --- Show instruction only near PollutionTarget ---
        if (pollutionTarget != null && instructionText != null && !instructionShown)
        {
            float dist = Vector3.Distance(mainCamera.transform.position, pollutionTarget.position);

            if (dist < showDistance)
            {
                instructionText.text = "Click on the trash to clean the river!";
                instructionShown = true;
            }
        }

        // --- Handle mouse clicks on trash ---
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked: " + hit.collider.name);

                if (hit.collider.CompareTag("Trash"))
                {
                    Destroy(hit.collider.gameObject);
                    trashLeft--;

                    ShowBobDialog(); // << show Bob message when trash is clicked

                    if (trashLeft <= 0)
                    {
                        ShowWinMessage();
                    }
                }

                if (clickMarkerPrefab != null)
                {
                    Instantiate(clickMarkerPrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }

    void ShowBobDialog()
    {
        if (bobDialogText != null && bobMessages.Length > 0)
        {
            bobDialogText.gameObject.SetActive(true);
            bobDialogText.text = bobMessages[currentMessageIndex];

            // Go to next message, loop if needed
            currentMessageIndex++;
            if (currentMessageIndex >= bobMessages.Length)
                currentMessageIndex = 0;
        }
    }

    void ShowWinMessage()
    {
        Debug.Log("All trash cleared!");

        if (pollutedWater != null) pollutedWater.SetActive(false);
        if (cleanWater != null) cleanWater.SetActive(true);

        if (winMessageUI != null) winMessageUI.SetActive(true);
        if (restartButton != null) restartButton.gameObject.SetActive(true);

        if (instructionText != null) instructionText.text = "Good job! You cleaned the river!";

        // Optional: Bob congratulates
        if (bobDialogText != null)
        {
            bobDialogText.text = "Great work! The river is clean now!";
            bobDialogText.gameObject.SetActive(true);
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
