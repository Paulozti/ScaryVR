using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSimulator : MonoBehaviour
{

    Vector3 neckmov;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if (UNITY_EDITOR)
        neckmov = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        transform.Rotate(neckmov);
#endif

    }
}
