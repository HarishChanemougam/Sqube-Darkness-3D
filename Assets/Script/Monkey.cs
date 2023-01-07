using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Monkey : MonoBehaviour
{
                //Monkey//
    [SerializeField] MeshRenderer _MonkeyRenderer;
    [SerializeField] Material _MonkeyMaterialIdle;
    [SerializeField] Material _MonkeyMaterialHover;

               //Player//
    [SerializeField] Material _materalIdle;
    [SerializeField] GameObject _player;
    [SerializeField] GameOver _gameOver;

    float _timeLeft = 5f; 
    bool _timeRunning = false;


    private void Update()
    {
        if(_timeRunning)
        {
            _timeLeft -= Time.deltaTime;

            if(_timeLeft < 0)
            {
                Destroy(_player);
               _gameOver.EndGame();
            }
        }
    }
    private void OnTriggerEnter(Collider collider)
    {       
       if(collider.gameObject.tag == "Player")
       {
            _MonkeyRenderer.material = _MonkeyMaterialHover;

            if (_timeLeft > 0)
            {
                if (_materalIdle == true)
                {       
                    _timeRunning = true;
                    _timeLeft = 5f;
                }
            }
        }        
    }


    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject)
        {
            _MonkeyRenderer.material = _MonkeyMaterialIdle;
            _timeRunning = false;
        }
    }

}
