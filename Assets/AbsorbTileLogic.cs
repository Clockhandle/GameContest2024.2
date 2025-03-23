using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbTileLogic : MonoBehaviour
{
    public const int amountToAbsorb = 1000;
    private int counter = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("WaterParticle"))
        {
            Destroy(collision.gameObject);
            counter++;
            if(counter >= amountToAbsorb)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
