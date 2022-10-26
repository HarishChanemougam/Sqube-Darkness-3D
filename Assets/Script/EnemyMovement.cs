using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float _moveSpeed; 
    [SerializeField] float _attackDistance; 
    [SerializeField] Animator _animator; 
    [SerializeField] PlayerMovement _player; 
    [SerializeField] CharacterController _characterController; 
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Transform _playerPos;

    [SerializeField] PlayerHealth _PlayerHealth;
    Vector3 _Vector; 
    Vector3 _direction; 
    CharacterController _enemy; 
    bool idle_normal; 
    bool idle_combat; 
    bool dead; 
    bool damage_001; 
    bool attack_short_001;
    bool move_forward => _Vector.magnitude > 0.01f; 
    float move_forward_fast => _Vector.magnitude; 


    PlayerTag _target;
    /*bool _attack;*/
    Coroutine _attackRoutine;

    IEnumerator AttackRoutine() 
    {
        _PlayerHealth.Dammage();
       /* _attack = false; */
        yield return new WaitForSeconds(1f); 
        /*_attack = true; */
        _attackRoutine = null;


    }


    private void Start()
    {
        _enemy = GetComponent<CharacterController>();
        _direction = transform.forward * _moveSpeed * 3;
        _characterController.transform.rotation = Quaternion.Euler(0, _player.transform.rotation.eulerAngles.y, 0); 
        _player = FindObjectOfType<PlayerMovement>(); 
    }

    public void SetTarget(PlayerTag player) 
    {
        _target = player; 
    }
    internal void ClearTarget() 
    {
        _target = null; 
    }

    private void FixedUpdate()
    {

        Vector3 direction = Vector3.zero; 
        float distanceToPlayer = 1f; 

        if (_target != null) 
        {
            distanceToPlayer = Vector3.Distance(_target.transform.position, transform.position);

            direction = _target.transform.position - transform.position;
            direction.Normalize(); 
        }
        _Vector = direction * Time.deltaTime * _moveSpeed; 

        if (_target != null && distanceToPlayer < _attackDistance && _attackRoutine == null) 
        {
            _animator.SetTrigger("attack_short_001");   

            _attackRoutine = StartCoroutine(AttackRoutine());
        }
        else
        {
            _enemy.Move(_Vector);
        }

    }

}
