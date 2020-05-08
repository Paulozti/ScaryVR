using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWalk : MonoBehaviour
{
    public AudioSource steps;

    public CharacterController character;
    public Vector3 positionToGo;
    // Start is called before the first frame update
    void Start()
    {
        positionToGo = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diftowalk = positionToGo - transform.position;

        character.SimpleMove(diftowalk.normalized);
    }
}
