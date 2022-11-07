using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIBrain : MonoBehaviour
{
    #region Internal type
    enum AIState
    {
        PATROL = 1,
        CHASE = 2,
        CATCH = 3,
        ATTACK = 4
    }
    #endregion
    [SerializeField] Transform _root;
    [SerializeField] Transform[] _patrolPath;
    [SerializeField] float _destinationDistance;
    [SerializeField] float _loseDistance;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] DetectPlayer _detectPlayer;
    [SerializeField] EntityMovement _player;

    [ShowNonSerializedField] AIState _internalState;
    [ShowNonSerializedField] int _patrolCurrentIndex;
    [ShowNonSerializedField] float _patrolDistanceToDestination;


    void Reset()
    {
        _destinationDistance = 0.5f;
    }

    void Awake()
    {
        _internalState = AIState.PATROL;
        _agent.SetDestination(_patrolPath[_patrolCurrentIndex].position);
    }

    void Update()
    {
      
        switch (_internalState)
        {
            case AIState.PATROL:
               
                Patrol();

               
                if (_detectPlayer.Target != null) 
                {
                    _internalState = AIState.CHASE;
                }
                break;
            case AIState.CHASE:
                Chase();
                if (_detectPlayer.Target == null)   
                {
                    _internalState = AIState.PATROL;
                    break;
                }

                var distanceToPlayer = Vector3.Distance(_root.transform.position, _detectPlayer.Target.transform.position);

                if (distanceToPlayer < _loseDistance) 
                {
                    _internalState = AIState.CATCH;
                }

                break;
            case AIState.CATCH:
                Catch();
                if (_detectPlayer.Target == null)   
                {
                    _internalState = AIState.PATROL;
                    break;
                }
              
                var distanceToPlayer2 = Vector3.Distance(_root.transform.position, _detectPlayer.Target.transform.position);
                if (distanceToPlayer2 > _loseDistance) 
                {
                    _internalState = AIState.CHASE;

                }
                break;

            case AIState.ATTACK:
                Attack();

                if(_detectPlayer.Target == _player.transform)
                {
                    Destroy(gameObject);
                }
            
                break;

            default:
                break;
        }
    }


    public void Patrol()
    {
       
        var patrolDestination = _patrolPath[_patrolCurrentIndex].position;
        _patrolDistanceToDestination = Vector3.Distance(_root.transform.position, patrolDestination);
        if (_patrolDistanceToDestination < _destinationDistance)
        {
            _patrolCurrentIndex++;
           
            if (_patrolCurrentIndex >= _patrolPath.Length)
            {
                _patrolCurrentIndex = 0;
            }

            _agent.SetDestination(_patrolPath[_patrolCurrentIndex].position);
        }
    }

    public void Chase()
    {
       
        _agent.SetDestination(_detectPlayer.Target.transform.position);
    }

    public void Catch()
    {
        _agent.isStopped = true;
      
    }
    private void Attack()
    {
        if(Collider.FindObjectOfType<PlayerTag>())
        {
        Destroy(gameObject);
        }
    }

    #region EDITOR
#if UNITY_EDITOR
    [SerializeField, Foldout("Editor")] float _radiusGizmos = 0.5f;
    private void OnDrawGizmos()
    {
        if (_patrolPath == null || _patrolPath.Length == 0) return;

        if (Application.isEditor)
        {
            Gizmos.color = Color.blue;
            var pos = _patrolPath.Select(i => i.position).ToArray();
          
            Gizmos.color = Color.yellow;
            for (int i = 0; i < _patrolPath.Length - 1; i++)
            {
                Gizmos.DrawLine(_patrolPath[i].position, _patrolPath[i + 1].position);
            }
            Gizmos.DrawLine(_patrolPath[0].position, _patrolPath[pos.Length - 1].position);

          
            Gizmos.color = Color.blue;
            foreach (var el in pos)
            {
                Gizmos.DrawSphere(el, _radiusGizmos);
            }
        }
    }
#endif

    #endregion

}
