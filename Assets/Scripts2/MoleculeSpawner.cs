using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject moleculePrefab;
    public int numberOfMolecules = 10;
    public float dropletRadius = 4.5f;

    void Start()
    {
        if (moleculePrefab == null)
        {
            Debug.LogError("❌ Molecule prefab is not assigned!");
            return;
        }

        SpawnMolecules();
    }

    void SpawnMolecules()
    {
        for (int i = 0; i < numberOfMolecules; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * dropletRadius;
            Quaternion randomRot = Random.rotation;

            // ❌ Don't parent to this object → remove `transform`
            GameObject molecule = Instantiate(moleculePrefab, randomPos, randomRot);
        }

        Debug.Log($"✅ Spawned {numberOfMolecules} molecules inside the droplet.");
    }
}
