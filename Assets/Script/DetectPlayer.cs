using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] EnemyMovement _Enemy; 

    public void OnTriggerEnter(Collider collision)
    {
        if (collision is CharacterController)
        {
            if (collision.TryGetComponent<PlayerTag>(out var player)) 
            {
                _Enemy.SetTarget(player); 
            }
        }
    }

    public void OnTriggerExit(Collider collision) 
    {
        if (collision is CharacterController)
        {
            if (collision.TryGetComponent<PlayerTag>(out var player)) 
            {
                _Enemy.ClearTarget();
            }
        }
    }
}
