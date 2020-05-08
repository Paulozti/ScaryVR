using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorIsOpen = false;
    public bool locked = false;
    public bool rightSide = false;
    public Transform doorMesh;
    public AudioSource audio;
    public AudioClip lockedSound;
    public AudioClip openingSound;
    public bool inRange = false;

    private bool isMoving = false;
    // Start is called before the first frame update
    
   
    public IEnumerator Abre()
    {
        if (!isMoving)
        {
            if (rightSide)
            {
                while (doorMesh.transform.rotation.eulerAngles.y != 30)
                {
                    doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.Euler(0, 30, 0), Time.deltaTime + 0.01f);
                    isMoving = true;
                    yield return new WaitForEndOfFrame();
                    if (doorMesh.transform.rotation == Quaternion.Euler(0, 30, 0))
                    {
                        break;
                    }
                }
            }
            else
            {
                while (doorMesh.transform.rotation.eulerAngles.y != -150)
                {
                    doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.Euler(0, -150, 0), Time.deltaTime + 0.01f);
                    isMoving = true;
                    yield return new WaitForEndOfFrame();
                    if (doorMesh.transform.rotation == Quaternion.Euler(0, -150, 0))
                    {
                        break;
                    }
                }
            }
            doorIsOpen = true;
            isMoving = false;
        }
    }

    public IEnumerator Fecha()
    {
        if (!isMoving)
        {
            if (rightSide)
            {
                while (doorMesh.transform.rotation.eulerAngles.y != 180)
                {
                    doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime + 0.01f);
                    isMoving = true;
                    yield return new WaitForEndOfFrame();
                    if (doorMesh.transform.rotation == Quaternion.Euler(0, 180, 0))
                    {
                        break;
                    }
                }
            }
            else
            {
                while (doorMesh.transform.rotation.eulerAngles.y != 0)
                {
                    doorMesh.transform.rotation = Quaternion.Lerp(doorMesh.transform.rotation, Quaternion.identity, Time.deltaTime + 0.01f);
                    isMoving = true;
                    yield return new WaitForEndOfFrame();
                    if (doorMesh.transform.rotation == Quaternion.identity)
                    {
                        break;
                    }
                }
            }
            doorIsOpen = false;
            isMoving = false;
        }
    }

    public void DoorInteract()
    {
        if (!locked)
        {
            audio.clip = openingSound;
            audio.Play();
            if (doorIsOpen)
                StartCoroutine(Fecha());
            else
                StartCoroutine(Abre());
        }
        else
        {
            audio.clip = lockedSound;
            audio.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }
}
