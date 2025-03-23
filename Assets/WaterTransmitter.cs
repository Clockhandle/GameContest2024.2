using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTransmitter : MonoBehaviour
{
    public GameObject waterParticlePrefab;
    public Transform waterParticleSpawner;
    public float spreadRange = 0.1f;
    public float forceMin = 5f, forceMax = 10f; // Random force range
    public void OnReceivingWaterParticle()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-spreadRange, spreadRange),
            Random.Range(-spreadRange, spreadRange),
            0f // Assuming 2D, keep Z constant
        );

        Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(-30f, 30f)); // Random rotation

        GameObject water = Instantiate(waterParticlePrefab, waterParticleSpawner.position + randomOffset, randomRotation);

        Rigidbody2D rb = water.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 sprayDirection = new Vector2(Random.Range(-0.1f, -1f), Random.Range(-0.5f, -1f)).normalized;
            rb.AddForce(sprayDirection * Random.Range(forceMin, forceMax), ForceMode2D.Impulse);
        }
    }

}
