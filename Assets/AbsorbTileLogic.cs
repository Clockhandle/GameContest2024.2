using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbTileLogic : MonoBehaviour
{
    public const int amountToAbsorb = 1000;
    private int counter = 0;
    public float speed = 2f;
    public int maxrange = 2;
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
        if (collision.collider.CompareTag("Wall"))
        {
            speed *= -1f;
        }
    }

    private void Update()
    {
        Flunctuate();
    }

    private void Flunctuate()
    {
        if (this.gameObject.name == "AbsorbTile (1)")
        {
            return;
        }
        else
        {
            float flunctuate = Mathf.Sin(Time.time * 2) * maxrange;

            transform.position = new Vector3(flunctuate - 5, transform.position.y, transform.position.z);
        }
    }
}
