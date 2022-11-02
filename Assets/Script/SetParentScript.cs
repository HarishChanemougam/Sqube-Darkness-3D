using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParentScript : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        PlayerTag tag = collision.transform.GetComponentInParent<PlayerTag>();
        
        tag.gameObject.transform.SetParent(transform);

        Debug.Log("yep!");
    }

    private void OnCollisionExit(Collision collision)
    {
        PlayerTag tag = collision.transform.GetComponentInParent<PlayerTag>();

        tag.gameObject.transform.SetParent(null);
    }
}
