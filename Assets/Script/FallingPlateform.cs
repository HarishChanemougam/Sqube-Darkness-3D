using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        collision.rigidbody.useGravity = true;
        Destroy(gameObject, 0.5f);

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision == null)
        {
            collision.rigidbody.useGravity = false;
        }
    }

}
