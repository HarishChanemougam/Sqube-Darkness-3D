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

    [SerializeField] bool _groundPlayer;
    [SerializeField] Vector3 _playerVelocity;
    [SerializeField] float _gravityValue = -9.8f;
    [SerializeField] float _jumpForce;
    [SerializeField] float _pullDown = 3f;
    [SerializeField] Rigidbody _rb;
    [SerializeField] InputActionReference _input;
    [SerializeField] float _jumpHeight = 1f;

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
        _isJumping = true;
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

        float movZ = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        if(movZ != 0)
        {
            _groundPlayer = _characterController.isGrounded;

            if(_groundPlayer && _playerVelocity.y < 0)
            {
                _rb.velocity = new Vector2(_speed * movZ, _rb.velocity.y);
                _playerVelocity.y = 0f;
            }

            if(movY == 1 && ! _isJumping)
            {
                _rb.velocity = new Vector2(_rb.velocity.z, _jumpForce);

                _isJumping = true;
            }

            if(_input == _isJumping)
            {
                transform.localScale = new Vector2(1f, 1f);
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3f * _gravityValue);
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