using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _speed;
    [SerializeField] float _slowTime;
    [SerializeField] float _rotationSpeed;
    [SerializeField] Animator _animator;


    [SerializeField] bool _groundPlayer;
    [SerializeField] Vector3 _playerVelocity;
    [SerializeField] float _gravityValue = -9.8f;
    [SerializeField] float _jumpForce;
    [SerializeField] float _pullDown = 3f;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _jumpHeight = 1f;
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] InputActionReference _invisibilityInput;
    [SerializeField] InputActionReference _slowTimeInput;
    [SerializeField] InputActionReference _safeModeInput;
    [SerializeField] InputActionReference _blastInput;


    Vector3 _direction;
    bool _isJumping;
    bool _invisibility;
    bool _timeSlowing;
    bool _safeMode;
    bool _blast;

    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
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
    public bool SlowTime
    {
        get => _timeSlowing;
        set => _timeSlowing = value;
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
        ////////////////////////////////////MOVE/////////////////////////////////
        _moveInput.action.started += Move;
        _moveInput.action.performed += Move;
        _moveInput.action.canceled += StopMove;

        /////////////////////////////////////JUMP////////////////////////////////
        _jumpInput.action.started += Jump;

        /////////////////////////////////////INVISIBILITY////////////////////////
        _invisibilityInput.action.started += Invisib;
    
        /////////////////////////////////////SLOWTIME/////////////////////////////
        _slowTimeInput.action.started += Slow;

        ////////////////////////////////////SAFEMODE//////////////////////////////
        _safeModeInput.action.started += Safe;

        ////////////////////////////////////BLASTMODE/////////////////////////////
        _blastInput.action.started += BlastMode;

    }







    #region Move
    private void Move(InputAction.CallbackContext obj)
    {
        _direction = obj.ReadValue<Vector2>();
        _direction = new Vector3(0, 0, _direction.x);
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        _direction = Vector2.zero;
    }

    #endregion

    #region Jump
    private void Jump(InputAction.CallbackContext obj)
    {

        if (_characterController.isGrounded == true)
        {
            _direction.y = _jumpForce;           
        }
    }

    #endregion

    #region Invisibility
    private void Invisib(InputAction.CallbackContext obj)
    {
        _invisibility = true;
    }
    private void StopInvisib(InputAction.CallbackContext obj)
    {
        _invisibility = false;
    }

    #endregion

    #region SlowTime
    private void Slow(InputAction.CallbackContext obj)
    {
        _timeSlowing = true;
    }
    private void StopSlow(InputAction.CallbackContext obj)
    {
        _timeSlowing = false;
    }

    #endregion

    #region SafeMode
    private void Safe(InputAction.CallbackContext obj)
    {
        _safeMode = true;
    }
    private void StopSafe(InputAction.CallbackContext obj)
    {
        _safeMode = false;
    }

    #endregion

    #region Blast
    private void BlastMode(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
    private void StopBlastMode(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    #endregion

    private void Update()
    {
        Vector3 CalculatedDirection = _direction * Time.deltaTime * _speed;
        CalculatedDirection = _characterController.transform.TransformDirection(CalculatedDirection);

        float YAxis = _characterController.transform.localEulerAngles.y;
        float currentYAxis = _characterController.transform.localEulerAngles.y;
        float Value = Mathf.LerpAngle(currentYAxis, YAxis, Time.deltaTime * _rotationSpeed);
        _characterController.transform.rotation = Quaternion.Euler(0, Value, 0);


        // gravity
        // if is not grounded
        // CalculatedDirection += Vector3.down
        if(_characterController.isGrounded == false)
        {
            CalculatedDirection.y += _gravityValue * Time.deltaTime;
           
        }
        /*else
        {
            CalculatedDirection.y = 0f;
            Debug.Log("Is Not Grounded", this);
        }*/

        _characterController.transform.rotation = Quaternion.Euler(0, 0, 0);

        Debug.DrawRay(_characterController.transform.position, CalculatedDirection, Color.red, 1f);

        _characterController.Move(CalculatedDirection);
        _direction.y = CalculatedDirection.y;

    }
    #region Color
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "BlindSpot")
        {
            _animator.SetTrigger("2DPlayerEyeBlink");

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var cubeRenderer = cube.GetComponent<Renderer>();

            cubeRenderer.material.SetColor("_color", Color.black);
        }

        else
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var cubeRenderer = cube.GetComponent<Renderer>();
            _animator.SetTrigger("2DPlayerEyeBlink2");
            cubeRenderer.material = (null);
        }
    }

    private void OnTriggerExit(Collider collision)
    {

    }

    #endregion
    private void FixedUpdate()
    {

        Vector3 CalculatedDirection = _direction * Time.deltaTime / _speed;
        if (_timeSlowing)
        {
            CalculatedDirection /= _slowTime;
        }
    }

}