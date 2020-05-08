using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    public GameObject lightToStop;

    private void OnTriggerEnter(Collider other)
    {
        lightToStop.SetActive(false);
    }
}
