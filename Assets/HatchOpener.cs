using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchOpener : MonoBehaviour
{
    public void OnBlackBoxTrigger()
    {
        gameObject.SetActive(false);
    }
}
