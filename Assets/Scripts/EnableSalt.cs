using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSalt : MonoBehaviour
{
    public GameObject saltToEnable;

    public bool shouldDisable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (saltToEnable != null && other.CompareTag("Player"))
        {
            if(shouldDisable)
                saltToEnable.SetActive(false);
            else
                saltToEnable.SetActive(true);
        }
    }
}
