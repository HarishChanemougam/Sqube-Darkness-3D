using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.AI;
using NaughtyAttributes.Test;

public class MonkeyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _traget;
    [SerializeField] float _radius = 10f;


    private void Start()
    {
        _traget = PlayerTag.instance.player.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(_traget.position, transform.position);

        if(distance <= _radius)
        {
            _agent.SetDestination(_traget.position);

            if(distance <= _agent.stoppingDistance)
            {
                //Attack The Target
                FaceTarget();
            }
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (_traget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, direction.x, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
