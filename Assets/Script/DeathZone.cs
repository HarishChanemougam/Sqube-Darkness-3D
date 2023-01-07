using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    [SerializeField] GameOver _gameOver;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            _gameOver.EndGame();
            Debug.Log("Destroyed");
        }
    }

    private void OnTriggerExit(Collider collision)
    {

    }
}
