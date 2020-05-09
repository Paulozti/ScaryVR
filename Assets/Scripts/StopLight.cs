using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    public GameObject lightToStop;
    public GameObject lightToHide;

    private void OnTriggerEnter(Collider other)
    {
        lightToStop.SetActive(false);
        if(lightToHide != null)
            lightToHide.SetActive(false);
    }
}
