using UnityEngine;
using System.Collections;

public class PhaseMoverAuto : MonoBehaviour
{
    public Transform startPosition;
    public Transform condensationTarget;
    public Transform precipitationTarget;
    public Transform collectionTarget;
    public Transform pollutionTarget;
    public Transform houseTarget; // PHASE 6 TARGET

    public float speed = 1.0f;
    public float waitTime = 2.0f;

    public GameObject bob;
    public Transform[] WaterPos; // assign 6 empty GameObjects now (0–5)

    private bool reachedPollutionPhase = false;
    private bool waitingForNext = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (bob != null) bob.SetActive(false);

        StartCoroutine(MoveThroughPhases());
    }

    private IEnumerator MoveThroughPhases()
    {
        // PHASE 1
        transform.position = startPosition.position;
        if (bob != null && WaterPos.Length > 0) bob.transform.position = WaterPos[0].position;
        if (bob != null) bob.SetActive(true);
        yield return new WaitForSeconds(waitTime);

        // PHASE 2
        if (bob != null && WaterPos.Length > 1) bob.transform.position = WaterPos[1].position;
        yield return MoveToTarget(condensationTarget);
        yield return new WaitForSeconds(waitTime);

        // PHASE 3
        if (bob != null && WaterPos.Length > 2) bob.transform.position = WaterPos[2].position;
        yield return MoveToTarget(precipitationTarget);
        yield return new WaitForSeconds(waitTime);

        // PHASE 4
        if (bob != null && WaterPos.Length > 3) bob.transform.position = WaterPos[3].position;
        yield return MoveToTarget(collectionTarget);
        yield return new WaitForSeconds(waitTime);

        // PHASE 5: Pollution
        if (bob != null && WaterPos.Length > 4) bob.transform.position = WaterPos[4].position;
        yield return MoveToTarget(pollutionTarget);

        reachedPollutionPhase = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Wait until Next button is clicked
        waitingForNext = true;
        while (waitingForNext)
        {
            yield return null;
        }

        // PHASE 6: House
        if (bob != null && WaterPos.Length > 5) bob.transform.position = WaterPos[5].position;
        yield return MoveToTarget(houseTarget);

        // (Optional) restart cycle after house
        StartCoroutine(MoveThroughPhases());
    }

    private IEnumerator MoveToTarget(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            yield return null;
        }
    }

    // Called by the "Next" button
    public void NextToHouse()
    {
        reachedPollutionPhase = false;
        waitingForNext = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
