using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] SceneManager  _levels;
    [SerializeField] PlayerMovement _player;


    public void select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider == _player)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        
    }


}
