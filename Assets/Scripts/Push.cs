using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    public Rigidbody objectToPush;


    private void OnTriggerEnter(Collider other)
    {
        if(objectToPush != null)
            pushObject();
    }

    private void pushObject()
    {
        objectToPush.AddForce(Vector3.back * 1000 + Vector3.left * 1000);
    }
}
