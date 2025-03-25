using UnityEngine;

public class FanLogic : MonoBehaviour
{
    public float windStrength = 5f; // Strength of the wind

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 windDirection = transform.up; // Get direction based on rotation
            rb.AddForce(windDirection * windStrength, ForceMode2D.Force);
        }
    }
}
