using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWaterParticle : MonoBehaviour
{
    private bool isFlipped = false;

    public bool IsGravityFlipped { get { return isFlipped; } }
    public void FlipGravity()
    {
        isFlipped = !isFlipped;

        foreach (Transform child in transform) // Loop through all children
        {
            Rigidbody2D rb = child.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale *= -1; // Flip gravity scale
            }
        }
    }
}
