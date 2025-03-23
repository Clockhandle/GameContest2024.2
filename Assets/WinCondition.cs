using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public Collider2D triggerBox;
    public int winCondition = 50;
    private int winCount = 0;
    private void Start()
    {
        triggerBox = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WaterParticle"))
        {
            //Destroy(other.gameObject);
            winCount++;

            if(winCount >= winCondition)
            {
                Debug.Log("Win!");
                triggerBox.enabled = false;
            }
        }
    }
}
