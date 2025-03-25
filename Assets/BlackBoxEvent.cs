using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlackBoxEvent : MonoBehaviour
{


    public UnityEvent onBlackBox1Trigger;
    public UnityEvent onBlackBox2Trigger;
    public UnityEvent onBlackBox3Trigger;

    private void Start()
    {
        
    }
    public void TriggerEvent()
    {
        if (gameObject.name == "Possibility1")
        {
            onBlackBox1Trigger?.Invoke();
        }
        else if(gameObject.name == "Possibility2")
        {
            onBlackBox2Trigger?.Invoke();
        }
        else if(gameObject.name == "Possibility3")
        {
            onBlackBox3Trigger?.Invoke();
        }
    }
}
