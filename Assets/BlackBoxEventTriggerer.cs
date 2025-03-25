using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlackBoxEventTriggerer : MonoBehaviour
{

    public const int numOfWaterParticleToDestroy = 30;
    private int counter = 0;
    private bool eventTrigger = true;
    private void Start()
    {   
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("WaterParticle"))
        {
            if (counter <= numOfWaterParticleToDestroy)
            {
                Destroy(other.gameObject);
                counter++;
            }
            else if(eventTrigger)
            {
                int childCount = transform.childCount;
                if (childCount == 0) return; // Safety check

                // Pick a random child index
                int randomIndex = Random.Range(0, childCount);
                Transform selectedChild = transform.GetChild(randomIndex);
                BlackBoxEvent eventScript = selectedChild.GetComponent<BlackBoxEvent>();
                if (eventScript != null)
                {
                    eventScript.TriggerEvent(); // Call the function inside BlackBoxEvents
                }
                eventTrigger = false;
            }
            else if(!eventTrigger)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
