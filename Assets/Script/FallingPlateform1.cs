using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateform1 : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            other.attachedRigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.attachedRigidbody == null)
        {
            other.attachedRigidbody.useGravity = true;
        }
    }
}
