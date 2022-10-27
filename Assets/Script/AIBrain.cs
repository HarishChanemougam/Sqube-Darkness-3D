using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AIBrain : MonoBehaviour
{
    #region Internal type
    enum AIState
    {
        PATROL,
        CHASE,
        CATCH
    }
    #endregion

    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Sensor _vision;
    [SerializeField] Transform _player;
    [SerializeField] Transform[] _path;
    [SerializeField] float _catchDistance;
   

    

    AIState _state;
    int _pathIndex;



    private void Start()
    {
        _state = AIState.PATROL;
        _pathIndex = 0;
        _agent.SetDestination(_path[1].position);

        
    }
    private void Update()
    {
        switch (_state)
        {
            case AIState.PATROL:
                if (_agent.remainingDistance < _agent.stoppingDistance)
                {
                    _pathIndex++;
                    if (_pathIndex >= _path.Length)
                    {
                        _pathIndex = 0;
                    }
                    _agent.SetDestination(_path[_pathIndex].position);
                }

                break;

            case AIState.CHASE:

                _agent.SetDestination(_player.position);

                if (_vision.PlayerFound == null)
                {
                    _state = AIState.PATROL;
                }
                _agent.SetDestination(_vision.PlayerFound.transform.position);

                if (Vector3.Distance(_agent.transform.position, _vision.PlayerFound.transform.position) < 1f)
                {
                    _state = AIState.CATCH;
                }
                break;

            case AIState.CATCH:
                SceneManager.LoadScene(0);

                break;


            default:
                break;
        }



    }
}
