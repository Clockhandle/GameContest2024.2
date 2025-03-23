using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaterReceiver : MonoBehaviour
{
    public UnityEvent onReceivingWaterParticle;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WaterParticle"))
        {
            Destroy(collision.gameObject);
            onReceivingWaterParticle?.Invoke();
        }
    }
}
