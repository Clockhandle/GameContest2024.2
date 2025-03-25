using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMultiplier : MonoBehaviour
{
    public GameObject waterParticlePrefab;
    public Vector3 startPosition;
    public float spawnInterval = 0.01f;
    private void Start()
    {
        startPosition = transform.position;
    }
    public void OnBlackBoxTrigger()
    {
        int multiplier = Mathf.Max(1, transform.childCount / 2); // Ensure at least 1

        StartCoroutine(SpawnWaterParticles(multiplier)); // Start coroutine
    }
    private IEnumerator SpawnWaterParticles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(waterParticlePrefab, startPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next
        }
    }
}
