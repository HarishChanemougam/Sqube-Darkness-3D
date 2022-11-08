using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameOver _gameOver;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.attachedRigidbody.gameObject.tag == "player")
        {
            Destroy(collision.attachedRigidbody.gameObject);
            _gameOver.EndGame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
