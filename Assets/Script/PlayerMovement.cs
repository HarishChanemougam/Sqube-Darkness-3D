using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;
using System;
using UnityEditor.Rendering.LookDev;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] InputActionReference _SlowTimeInput;
    [SerializeField] InputActionReference _invisibilityInput;
    [SerializeField] InputActionReference _SafeModeInput;
    [SerializeField] InputActionReference _blastInput;
    [SerializeField] EntityMovement _movement;
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody _rb;
   
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();

        _moveInput.action.started += Move;
        _moveInput.action.performed += Move;
        _moveInput.action.canceled += End;


        _jumpInput.action.started += StartJump;
        _jumpInput.action.canceled += StopJump;
        
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            print("CharacterController is grounded");
        }
    }

        private void FixedUpdate()
    {
        _SlowTimeInput.action.started += StartTime;
        _SlowTimeInput.action.canceled += StopTime;


        _invisibilityInput.action.started += StartInvisibility;
        _invisibilityInput.action.canceled += StopInvisibility;


        _SafeModeInput.action.started += StartSafeMode;
        _SafeModeInput.action.canceled += StopSafeMode;


        _blastInput.action.started += StartBlast;
        _blastInput.action.canceled += StopBlast;
    }


    private void OnDestroy()
    {
        _moveInput.action.started -= Move;
        _moveInput.action.performed -= Move;
        _moveInput.action.canceled -= End;


        _jumpInput.action.started -= StartJump;
        _jumpInput.action.canceled -= StopJump;


        _SlowTimeInput.action.started -= StartTime;
        _SlowTimeInput.action.canceled -= StopTime;
    }


    ///Move///
    private void Move(InputAction.CallbackContext obj)
    {
        Vector2 dir = obj.ReadValue<Vector2>();
        _movement.Direction = new Vector3(0, dir.y, dir.x);
    }
  
    private void End(InputAction.CallbackContext obj)
    {
        _movement.Direction = Vector2.zero;
    }


    ///Jump///
    private void StartJump(InputAction.CallbackContext obj)
    {
        _movement.IsJumping = true;
       
    }
  
    private void StopJump(InputAction.CallbackContext obj)
    {
        _movement.IsJumping = false;

        var forceEffect = obj.duration;
        _rb.AddForce(Vector3.up * (10f * (float)forceEffect), ForceMode.Impulse);
    }


    ///Time///
    private void StartTime(InputAction.CallbackContext obj)
    {
        _movement.SlowTime = true;
    }
 
    private void StopTime(InputAction.CallbackContext obj)
    {
        _movement.SlowTime = false;
    }


    ///Invisibility///
    private void StartInvisibility(InputAction.CallbackContext obj)
    {
        _movement.Invisibility = true;
    }
 
    private void StopInvisibility(InputAction.CallbackContext obj)
    {
        _movement.Invisibility = false;
    }


    ///SafeMode///
    private void StartSafeMode(InputAction.CallbackContext obj)
    {
        _movement.SafeMode = true;
    }

    private void StopSafeMode(InputAction.CallbackContext obj)
    {
        _movement.SafeMode = false;
    }


    ///Blast///
    private void StartBlast(InputAction.CallbackContext obj)
    {
        _movement.Blast = true;
    }

    private void StopBlast(InputAction.CallbackContext obj)
    {
        _movement.Blast = false;
    }

    #region colorChange
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
            _animator.SetTrigger("2DPlayerEyeBlink2");
        }
    }

    #endregion
}
