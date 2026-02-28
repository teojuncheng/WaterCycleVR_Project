using UnityEngine;

public class WaterMoleculeBehavior : MonoBehaviour
{
    public float baseSpeed = 1f;
    private Vector3 direction;
    private float temperatureMultiplier = 1f;
    private float boundsRadius = 9f;

    private Renderer rend;

    void Start()
    {
        direction = Random.onUnitSphere.normalized;

        // Try get renderer from self or first child
        rend = GetComponent<Renderer>();
        if (rend == null && transform.childCount > 0)
        {
            rend = transform.GetChild(0).GetComponent<Renderer>();
        }

        // 🔧 Ensure each molecule has a unique material instance
        if (rend != null)
        {
            rend.material = new Material(rend.material);
        }
    }

    void Update()
    {
        // Move molecule
        transform.Translate(direction * baseSpeed * temperatureMultiplier * Time.deltaTime);

        // Bounce off boundary
        if (transform.position.magnitude > boundsRadius)
        {
            direction = -direction;
            transform.position = transform.position.normalized * boundsRadius * 0.99f;
        }
    }

    public void SetTemperature(float temperature)
    {
        // Adjust movement speed based on temperature
        temperatureMultiplier = Mathf.Clamp(temperature / 25f, 0.1f, 6f);

        // Change color based on temperature
        if (rend != null)
        {
            Color color;
            if (temperature <= 0f)
                color = Color.blue;
            else if (temperature >= 100f)
                color = Color.red;
            else
                color = Color.Lerp(Color.blue, Color.red, temperature / 100f);

            rend.material.color = color;
        }
    }
}
