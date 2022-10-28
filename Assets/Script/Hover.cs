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
            Debug.Log("red");
        }
        else
        {
            _renderer.material = _materalIdle;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<BlindSpotTag>() != null)
    //    {
    //        _renderer.material = _materialHover;
    //        Debug.Log("red");
    //    }
    //    else
    //    {
    //        _renderer.material = _materalIdle;
    //    }
    //}
    //
    //private void OnTriggerExit(Collider other)
    //{
    //    
    //}
}
