using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] Vector3 _moveInput;
    [SerializeField] Vector3 _jumpInput;
    [SerializeField] float _jumpHeight = 1f;

    private void Awake()
    {
        _playerMovement = new PlayerMovement();

        _rb = GetComponent<Rigidbody>();

        if(_rb is null)
        {
            Debug.LogError("Rigidbody is NULL§");
        }
    }




}