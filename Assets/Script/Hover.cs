using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour
{
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Material _materalIdle;
    [SerializeField] Material _materialHover;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BlindSpotTag>() != null)
        {
            _renderer.material = _materialHover;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<BlindSpotTag>() != null)
        {
            _renderer.material = _materalIdle;
        }

    }

}
