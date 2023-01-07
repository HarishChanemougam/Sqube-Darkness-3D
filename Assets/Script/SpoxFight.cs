using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpoxFight : MonoBehaviour
{
    [SerializeField] GameOver _gameOver;
    [SerializeField] GameObject _player;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            _gameOver.EndGame();
            Debug.Log("death");

        }
    }

    private void OnTriggerExit(Collider collider)
    {

    }


}
