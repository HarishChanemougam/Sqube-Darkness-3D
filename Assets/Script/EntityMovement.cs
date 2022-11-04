using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _speed;
    [SerializeField] float _slowTime;
    [SerializeField] float _rotationSpeed;


    [SerializeField] float _gravity = 9f;
    [SerializeField] float _jumpForce;
    [SerializeField] float _pullDown = 3f;
    [SerializeField] Rigidbody _rb;

    Vector3 _direction;
    bool _isJumping;
    bool _timeSlowing;
    bool _invisibility;
    bool _safeMode;
    bool _blast;

    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public bool SlowTime
    {
        get => _timeSlowing;
        set => _timeSlowing = value;
    }

    public bool IsJumping
    {
        get => _isJumping;
        set => _isJumping = value;
    }

    public bool Invisibility
    {
        get => _invisibility;
        set => _invisibility = value;
    }

    public bool SafeMode
    {
        get => _safeMode;
        set => _safeMode = value;
    }

    public bool Blast
    {
        get => _blast;
        set => _blast = value;
    }


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(_characterController.isGrounded)
        {
            print("CharacterController is grounded");
        }

        Vector3 CalculatedDirection = _direction * Time.deltaTime * _speed;

        CalculatedDirection = _characterController.transform.TransformDirection(CalculatedDirection);
        CalculatedDirection.y = 0;

        _characterController.Move(CalculatedDirection);

        float YAxis = _characterController.transform.localEulerAngles.y;
        float currentYAxis = _characterController.transform.localEulerAngles.y;
        float Value = Mathf.LerpAngle(currentYAxis, YAxis, Time.deltaTime * _rotationSpeed);
        _characterController.transform.rotation = Quaternion.Euler(0, Value, 0);

        if(_characterController.isGrounded)
        {
            CalculatedDirection.y = 0;
        }

        else
        {
            CalculatedDirection.y += _gravity * Time.deltaTime;
        }

        if(_isJumping)
        {
            _isJumping = false;

            if(_characterController.isGrounded)
            {
                CalculatedDirection.y = _jumpForce;
                _rb.AddForce(Vector3.up * 15f, ForceMode.Impulse);
            }
        }
       
    }

    private void FixedUpdate()
    {
        Vector3 CalculatedDirection = _direction * Time.deltaTime / _speed;
        if (_timeSlowing)
        {
            CalculatedDirection /= _slowTime;
        }
    }



}