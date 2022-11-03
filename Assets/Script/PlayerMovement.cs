using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] Animator _animator;
    [SerializeField] EntityMovement _movement;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _moveSpeed;

    private void Start()
    {
        _moveInput.action.started += MoveUpdate;
        _moveInput.action.performed += MoveUpdate;
        _moveInput.action.canceled += MoveStop;

        _jumpInput.action.started += LaunchJump;
    }

    internal void StopInput()
    {
        _movement.Direction = Vector3.zero;
        _moveInput.action.actionMap.Disable();
    }

    private void LaunchJump(InputAction.CallbackContext obj)
    {
        _movement.Jump = true;
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= MoveUpdate;
        _moveInput.action.performed -= MoveUpdate;
        _moveInput.action.canceled -= MoveStop;
    }

    private void MoveUpdate(InputAction.CallbackContext obj)
    {
        float movez = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        _movement.Direction = new Vector3(0, movey, movez).normalized;

        
    }

    private void MoveStop(InputAction.CallbackContext obj)
    {
        _movement.Direction = Vector3.zero;
    }

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


}
