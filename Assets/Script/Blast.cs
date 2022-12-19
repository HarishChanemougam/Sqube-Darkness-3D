using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    [SerializeField] GameObject _SkyPatrole;
    [SerializeField] GameObject _Blast;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_SkyPatrole);
            Destroy(_Blast);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
       
    }

   
}
