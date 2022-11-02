using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField] Vector3 _playerVelocity;
    [SerializeField] bool _groundedPlayer;
    [SerializeField] float _playerSpeed = 2.0f;
    [SerializeField] float _jumpHeight = 1.0f;
    [SerializeField] float _gravityValue = -9.81f;
    [SerializeField] Animator _animator;
    [SerializeField] InputActionReference _input;
    [SerializeField] GameObject _platform;

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        _groundedPlayer = _controller.isGrounded;
        if(_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        /*Vector3 move = new Vector3(0, 0, Input.GetAxis("Horizontal"));*/
        _playerVelocity.z = (Input.GetAxis("Horizontal")  * _playerSpeed);

                
            gameObject.transform.forward = _playerVelocity.normalized;




        if (Input.GetButton("Jump") && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
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
