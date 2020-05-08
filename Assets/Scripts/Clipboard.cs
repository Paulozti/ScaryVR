using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    public GameObject canvas;
    private bool canvasOnScreen = false;
    public bool canOpen = true;
    private void Update()
    {
        if (canvasOnScreen)
        {
            StartCoroutine(HideCanvas());
            canvasOnScreen = false;
        }

    }

    IEnumerator HideCanvas() {

        yield return new WaitForSeconds(5);
        canvas.SetActive(false);
        StartCoroutine(CanOpen());
    }

    public void ShowCanvas()
    {
        canvas.SetActive(true);
        canvasOnScreen = true;
        canOpen = false;
    }

    IEnumerator CanOpen()
    {
        yield return new WaitForSeconds(5);
        canOpen = true;
    }

}
