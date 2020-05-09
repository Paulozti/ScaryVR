using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScare : MonoBehaviour
{
    public Transform scareDoor;
    

    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FullClose());
    }

    IEnumerator FullClose()
    {
        while (scareDoor.transform.rotation.eulerAngles.y != 0)
        {
            scareDoor.transform.rotation = Quaternion.Lerp(scareDoor.transform.rotation, Quaternion.Euler(0, 5, 0), Time.deltaTime + 0.1f);
            yield return new WaitForEndOfFrame();
            if (scareDoor.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                break;
            }
        }
        //scareDoor.transform.rotation = Quaternion.Lerp(scareDoor.transform.rotation, Quaternion.Euler(0, 1, 0), 0.5f + Time.deltaTime);
    }
}
